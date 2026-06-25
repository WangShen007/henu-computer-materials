import struct
import os
import glob


def parse_packet_file(filepath):
    """
    Parses the custom packet file format.
    Extracts the hex bytes from the line starting with '|0'.
    Returns bytes object of the packet (including ethernet header).
    """
    with open(filepath, "r", encoding="utf-8") as f:
        lines = f.readlines()

    packet_hex = []

    for line in lines:
        line = line.strip()
        if line.startswith("|0"):
            # Example: |0   |10|e7|c6|4a|82|f4|60|10|9e|69|c2|9e|08|00|45|00|00|...
            parts = line.split("|")
            # Filter out empty strings and the index '0'
            for part in parts:
                part = part.strip()
                if part and part != "0":
                    try:
                        packet_hex.append(int(part, 16))
                    except ValueError:
                        pass

    return bytes(packet_hex)


def calculate_checksum(data):
    """
    Calculates the 16-bit one's complement sum of the data.
    """
    if len(data) % 2 == 1:
        data += b"\x00"

    s = 0
    for i in range(0, len(data), 2):
        w = (data[i] << 8) + (data[i + 1])
        s += w

    s = (s >> 16) + (s & 0xFFFF)
    s += s >> 16

    return ~s & 0xFFFF


def verify_checksum(name, calculated, expected):
    result = (
        "PASS" if calculated == 0 or calculated == expected else "FAIL"
    )  # If calculated matches 0 (validation way) or matches expected field
    # Usually validation: calc(header with checksum) == 0 (or 0xffff)
    # Or calc(header with 0 checksum) == expected
    # We will use the approach: set checksum field to 0, calculate, compare with original.
    pass


def validate_ip_checksum(ip_header):
    """
    Validates IP header checksum.
    """
    # IP Header format:
    # Version(4)+IHL(4), TOS(8), Total Length(16)
    # ID(16), Flags(3)+Fragment Offset(13)
    # TTL(8), Protocol(8), Header Checksum(16)
    # Src IP(32)
    # Dst IP(32)

    if len(ip_header) < 20:
        return False, 0, 0

    ihl = (ip_header[0] & 0x0F) * 4
    header_data = ip_header[:ihl]

    original_checksum = struct.unpack(">H", header_data[10:12])[0]

    # Set checksum to 0 for calculation
    header_for_calc = bytearray(header_data)
    header_for_calc[10] = 0
    header_for_calc[11] = 0

    calculated_checksum = calculate_checksum(header_for_calc)

    return (
        calculated_checksum == original_checksum,
        calculated_checksum,
        original_checksum,
    )


def validate_transport_checksum(ip_packet, protocol_name):
    """
    Validates TCP/UDP/ICMP checksum.
    """
    ihl = (ip_packet[0] & 0x0F) * 4
    src_ip = ip_packet[12:16]
    dst_ip = ip_packet[16:20]
    protocol = ip_packet[9]
    ip_payload = ip_packet[ihl:]

    # Pseudo Header
    # Source Address (4 bytes)
    # Destination Address (4 bytes)
    # Reserved (1 byte) -> 0
    # Protocol (1 byte)
    # Length (2 bytes) -> Length of TCP/UDP/ICMP segment

    length = len(ip_payload)
    pseudo_header = struct.pack("!4s4sBBH", src_ip, dst_ip, 0, protocol, length)

    if protocol_name == "ICMP":
        checksum_offset = 2
    elif protocol_name == "TCP":
        checksum_offset = 16
    elif protocol_name == "UDP":
        checksum_offset = 6
    else:
        return False, 0, 0

    if len(ip_payload) < checksum_offset + 2:
        return False, 0, 0

    original_checksum = struct.unpack(
        ">H", ip_payload[checksum_offset : checksum_offset + 2]
    )[0]

    # Set checksum to 0
    segment_for_calc = bytearray(ip_payload)
    segment_for_calc[checksum_offset] = 0
    segment_for_calc[checksum_offset + 1] = 0

    # Calculate checksum over Pseudo Header + Segment
    # To handle odd length correctly, concatenation works best or handle odd byte in data

    # Concatenate pseudo header and segment
    length = len(ip_payload)
    pseudo_header = struct.pack("!4s4sBBH", src_ip, dst_ip, 0, protocol, length)

    if protocol_name == "ICMP":
        checksum_offset = 2
        # ICMP does not use pseudo header
        data_to_checksum = segment_for_calc
    elif protocol_name == "TCP":
        checksum_offset = 16
        pseudo_header = struct.pack("!4s4sBBH", src_ip, dst_ip, 0, protocol, length)
        data_to_checksum = pseudo_header + segment_for_calc
    elif protocol_name == "UDP":
        checksum_offset = 6
        pseudo_header = struct.pack("!4s4sBBH", src_ip, dst_ip, 0, protocol, length)
        data_to_checksum = pseudo_header + segment_for_calc
    else:
        return False, 0, 0

    calculated_checksum = calculate_checksum(data_to_checksum)

    return (
        calculated_checksum == original_checksum,
        calculated_checksum,
        original_checksum,
    )


def main():
    packet_dir = r"改成你自己的路径,这个总会吧"

    # Map protocol byte to name
    proto_map = {1: "ICMP", 6: "TCP", 17: "UDP"}

    print(
        f"{'File':<40} {'Protocol':<10} {'Type':<10} {'Result':<10} {'Calc':<10} {'Orig':<10}"
    )
    print("-" * 100)

    files = glob.glob(os.path.join(packet_dir, "*.txt"))
    for file_path in files:
        filename = os.path.basename(file_path)
        try:
            raw_data = parse_packet_file(file_path)
            if not raw_data:
                print(f"{filename:<40} ERROR: Empty or invalid file")
                continue

            # Skip Ethernet Header (14 bytes)
            ip_packet = raw_data[14:]

            # 1. Validate IP Checksum
            is_valid_ip, calc_ip, orig_ip = validate_ip_checksum(ip_packet)
            print(
                f"{filename:<40} {'IP':<10} {'Header':<10} {'PASS' if is_valid_ip else 'FAIL':<10} {hex(calc_ip):<10} {hex(orig_ip):<10}"
            )

            # 2. Validate Protocol Checksum
            protocol_num = ip_packet[9]
            if protocol_num in proto_map:
                proto_name = proto_map[protocol_num]
                is_valid_proto, calc_proto, orig_proto = validate_transport_checksum(
                    ip_packet, proto_name
                )
                print(
                    f"{filename:<40} {proto_name:<10} {'Payload':<10} {'PASS' if is_valid_proto else 'FAIL':<10} {hex(calc_proto):<10} {hex(orig_proto):<10}"
                )

        except Exception as e:
            print(f"{filename:<40} ERROR: {str(e)}")


if __name__ == "__main__":
    main()
