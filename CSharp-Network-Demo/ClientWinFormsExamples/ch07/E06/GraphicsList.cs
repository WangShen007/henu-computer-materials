using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    [KnownType(typeof(GraphicsList))]
    [KnownType(typeof(DrawRectangle))]
    [KnownType(typeof(DrawArrowCurve))]
    [KnownType(typeof(DrawCurve))]
    [KnownType(typeof(DrawText))]
    [KnownType(typeof(DrawImage))]
    [KnownType(typeof(DrawEllipse))]
    public class GraphicsList
    {
        [DataMember]
        private List<DrawObject> _graphicsList = new();

        public PanelUC? UC1 { get; set; }

        /// <summary>索引</summary>
        public IEnumerable<DrawObject> Selection
        {
            get
            {
                foreach (DrawObject o in _graphicsList)
                {
                    if (o.Selected)
                    {
                        yield return o;
                    }
                }
            }
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

        public GraphicsList()
        {
        }

        /// <summary>画图</summary>
        public void Draw(Graphics g)
        {
            DrawObject w;
            for (int i = 0; i < _graphicsList.Count; i++)
            {
                w = _graphicsList[i];

                if (w.IntersectsWith(Rectangle.Round(g.ClipBounds)))
                {
                    w.Draw(g);
                }

                if (w.Selected == true)
                {
                    w.DrawHandle(g);
                }
            }
        }

        /// <summary>选择的对象个数</summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawObject w in _graphicsList)
                {
                    if (w.Selected) n++;
                }
                return n;
            }
        }

        /// <summary>选择的对象</summary>
        public DrawObject? GetSelectedObject(int index)
        {
            int n = -1;
            foreach (DrawObject w in _graphicsList)
            {
                if (w.Selected)
                {
                    n++;
                    if (n == index)
                        return w;
                }
            }
            return null;
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

        /// <summary>删除选中的图形</summary>
        public virtual void DeleteSelection()
        {
            int n = _graphicsList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                if (_graphicsList[i].Selected)
                {
                    _graphicsList.RemoveAt(i);
                }
            }
            UC1?.Refresh();
        }

        /// <summary>设置矩形框内选择的对象</summary>
        public void SelectInRectangle(Rectangle rectangle)
        {
            foreach (DrawObject w in _graphicsList)
            {
                if (w.IntersectsWith(rectangle))
                    w.Selected = true;
            }
        }

        /// <summary>全部选择</summary>
        public virtual void SelectAll()
        {
            foreach (DrawObject w in _graphicsList)
            {
                w.Selected = true;
            }
            UC1?.Refresh();
        }

        /// <summary>全部取消选择</summary>
        public virtual void UnselectAll()
        {
            foreach (DrawObject w in _graphicsList)
            {
                w.Selected = false;
            }
            UC1?.Refresh();
        }
        public virtual void DeleteSelectedObjects()
        {
            int count = _graphicsList.Count;
            string str = "";
            for (int i = 0; i < count; i++)
            {
                if (_graphicsList[i].Selected)
                {
                    str += string.Format("@{0}", _graphicsList[i].ID);
                }
            }
            if (str.Length == 0)
            {
                return;
            }
            DeleteSelection();
            UC1?.MyClient?.SendToServer($"DeleteObjects,{str.Remove(0, 1)}");
        }
    }
}
