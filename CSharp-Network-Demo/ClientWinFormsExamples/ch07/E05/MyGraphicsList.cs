namespace ClientWinFormsExamples.ch07.E05
{
    public class MyGraphicsList
    {
        private List<MyDrawObject> graphicsList = new();
        public IEnumerable<MyDrawObject> Selection
        {
            get
            {
                foreach (MyDrawObject o in graphicsList)
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
            graphicsList.Clear();
        }

        /// <summary>对象个数</summary>
        public int Count
        {
            get
            {
                return graphicsList.Count;
            }
        }

        public MyDrawObject? this[int index]
        {
            get
            {
                if (index < 0 || index >= graphicsList.Count)
                {
                    return null;
                }
                return graphicsList[index];
            }
        }

        public MyGraphicsList()
        {

        }

        /// <summary>画图</summary>
        public void Draw(Graphics g)
        {
            MyDrawObject w;
            if (graphicsList != null)
            {
                for (int i = 0; i < graphicsList.Count; i++)
                {
                    w = graphicsList[i];

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
        }

        /// <summary>选择的对象个数</summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (MyDrawObject w in graphicsList)
                {
                    if (w.Selected) n++;
                }
                return n;
            }
        }

        /// <summary>选择的对象</summary>
        public MyDrawObject? GetSelectedObject(int index)
        {
            int n = -1;
            foreach (MyDrawObject w in graphicsList)
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
        public void Add(MyDrawObject w)
        {
            graphicsList.Add(w);
        }

        /// <summary>删除指定对象</summary>
        public void Remove(int objID)
        {
            for (int i = graphicsList.Count - 1; i >= 0; i--)
            {
                if (graphicsList[i].ID == objID)
                {
                    graphicsList.RemoveAt(i);
                }
            }
        }

        /// <summary>删除选中的图形</summary>
        public virtual void DeleteSelection()
        {
            int n = graphicsList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                if (graphicsList[i].Selected)
                {
                    graphicsList.RemoveAt(i);
                }
            }
            MyCC.UC1.Refresh();
        }

        /// <summary>设置矩形框内选择的对象</summary>
        public void SelectInRectangle(Rectangle rectangle)
        {
            foreach (MyDrawObject w in graphicsList)
            {
                if (w.IntersectsWith(rectangle))
                    w.Selected = true;
            }
        }

        /// <summary>全部选择</summary>
        public virtual void SelectAll()
        {
            foreach (MyDrawObject w in graphicsList)
            {
                w.Selected = true;
            }
            MyCC.UC1.Refresh();
        }

        /// <summary>全部取消选择</summary>
        public virtual void UnselectAll()
        {
            foreach (MyDrawObject w in graphicsList)
            {
                w.Selected = false;
            }
            MyCC.UC1.Refresh();
        }

        public virtual void DeleteSelectedObjects()
        {
            int count = graphicsList.Count;
            string str = "";
            for (int i = 0; i < count; i++)
            {
                if (graphicsList[i].Selected)
                {
                    str += string.Format("@{0}", graphicsList[i].ID);
                }
            }
            if (str.Length == 0)
            {
                return;
            }
            DeleteSelection();
            MyCC.UC1.Refresh();
        }
    }
}
