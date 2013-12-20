using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Adam.Core
{
    public abstract class Command
    {
        public abstract void Execute();
    }

    public abstract class Command<TResult> : Command
    {
        public TResult Result { get; protected set; }
    }

}
