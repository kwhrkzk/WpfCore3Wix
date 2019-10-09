using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCore3
{
    public class ContentModel
    {
        public ReactiveProperty<string> Text { get; } = new ReactiveProperty<string>("Hello World");
    }
}
