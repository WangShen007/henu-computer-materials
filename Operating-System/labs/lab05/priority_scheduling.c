#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/* Define the Process Control Block (PCB) structure */
typedef struct _proc {
    char name[32];      /* Process Name */
    int run_time;       /* Required Running Time */
    int pri;            /* Priority */
    char state;         /* State: 'R' for Ready, 'E' for End */
    struct _proc *next; /* Pointer to the next process */
} PROC;

/* Global pointer to the head of the ready queue */
PROC *head = NULL;

/* Function to insert a process into the sorted queue (by priority) */
void insert_proc(PROC *p) {
    if (head == NULL) {
        head = p;
        p->next = NULL;
        return;
    }

    /* If p has higher priority than head, it becomes the new head */
    if (p->pri > head->pri) {
        p->next = head;
        head = p;
        return;
    }

    /* Find the correct position to insert */
    PROC *curr = head;
    PROC *prev = NULL;
    while (curr != NULL && curr->pri >= p->pri) {
        prev = curr;
        curr = curr->next;
    }

    /* Insert p after prev */
    p->next = curr;
    prev->next = p;
}

/* Function to print the process info and queue state */
void print_procs(PROC *procs, int count, PROC *current) {
    printf("Selected process: %s\n", current ? current->name : "None");
    printf("Queue State:\n");
    PROC *p = head;
    while (p != NULL) {
        printf("Name: %s, RunTime: %d, Priority: %d, State: %c\n",
               p->name, p->run_time, p->pri, p->state);
        p = p->next;
    }
    printf("--------------------------------------------------\n");
}

int main() {
    /* Initialize 5 processes with the given values */
    /*
       P1: Time=2, Pri=1
       P2: Time=3, Pri=5
       P3: Time=1, Pri=3
       P4: Time=2, Pri=4
       P5: Time=4, Pri=2
    */

    // Allocate memory for 5 processes
    PROC p1 = {"P1", 2, 1, 'R', NULL};
    PROC p2 = {"P2", 3, 5, 'R', NULL};
    PROC p3 = {"P3", 1, 3, 'R', NULL};
    PROC p4 = {"P4", 2, 4, 'R', NULL};
    PROC p5 = {"P5", 4, 2, 'R', NULL};

    /* Array of pointers to access them easily for initial setup if needed,
       but we will insert them into the list directly. */

    /* Insert them into the linked list sorted by priority */
    /* Order should be P2 -> P4 -> P3 -> P5 -> P1 */
    insert_proc(&p1);
    insert_proc(&p2);
    insert_proc(&p3);
    insert_proc(&p4);
    insert_proc(&p5);

    printf("Initial State:\n");
    print_procs(NULL, 5, NULL);

    int step = 0;
    while (head != NULL) {
        step++;
        printf("\nStep %d:\n", step);

        /* 1. Select the process at the head of the queue */
        PROC *run_proc = head;

        /* Remove it from the head efficiently to process it */
        head = head->next;

        /* 2. Run the process (Simulate run) */
        /* Priority - 1, RunTime - 1 */
        run_proc->pri -= 1;
        run_proc->run_time -= 1;

        /* 3. Check if finished */
        if (run_proc->run_time == 0) {
            run_proc->state = 'E';
            run_proc->next = NULL; /* Not in queue anymore */
            printf("Process %s finished.\n", run_proc->name);
        } else {
            /* 4. If not finished, insert back into the queue based on new priority */
            run_proc->state = 'R';
            /* Note: Check requires runtime != 0 (done above) */
            insert_proc(run_proc);
        }

        /* Print state after this step */
        /* Currently running process is run_proc, but print_procs iterates 'head' list.
           So run_proc handles the current one.
           Wait, the requirement says "Show changes in the process queue after running once".
           If it's finished, it's not in the queue.
           If it's re-inserted, it is in the queue.
        */
        print_procs(NULL, 0, run_proc);
    }

    printf("\nAll processes finished.\n");

    return 0;
}
