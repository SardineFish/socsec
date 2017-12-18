using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.EditorBuilder
{
    public abstract class EditorControl
    {
        public List<EditorControl> Childrens { get; protected set; }
        public abstract void BeginRender();
        public abstract void EndRender();

        public EditorControl()
        {
            Childrens = new List<EditorControl>();
        }

    }
}
