using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern.Structural
{
    public abstract class Component
    {
        public Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract void PrimaryOperation(int depth);   // this should be a more descriptive name in actual application

    }
}
