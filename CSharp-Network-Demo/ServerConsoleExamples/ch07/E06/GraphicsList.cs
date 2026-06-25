using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    [KnownType(typeof(GraphicsList))]
    [KnownType(typeof(DrawRectangle))]
    [KnownType(typeof(DrawCurve))]
    [KnownType(typeof(DrawArrowCurve))]
    [KnownType(typeof(DrawText))]
    [KnownType(typeof(DrawImage))]
    [KnownType(typeof(DrawEllipse))]
    public class GraphicsList
    {
        [DataMember] private List<DrawObject> _graphicsList = new List<DrawObject>();

        public GraphicsList()
        {
        }

        /// <summary>清除</summary>
        public void Clear()
        {
            _graphicsList.Clear();
        }

        /// <summary>对象个数</summary>
        public int Count
        {
            get
            {
                return _graphicsList.Count;
            }
        }

        /// <summary>获取图形对象</summary>
        public DrawObject? this[int index]
        {
            get
            {
                if (index < 0 || index >= _graphicsList.Count)
                {
                    return null;
                }
                return _graphicsList[index];
            }
        }

        /// <summary>添加图形对象</summary>
        public void Add(DrawObject w)
        {
            _graphicsList.Add(w);
        }

        /// <summary>删除指定对象</summary>
        public void Remove(int objID)
        {
            for (int i = _graphicsList.Count - 1; i >= 0; i--)
            {
                if (_graphicsList[i].ID == objID)
                {
                    _graphicsList.RemoveAt(i);
                }
            }
        }
    }
}
