using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.ChurchEncoding
{
    public class MaybeFlattened<T> : IMaybe<T>
    {
        private readonly IMaybe<IMaybe<T>> source;

        public MaybeFlattened(IMaybe<IMaybe<T>> source)
        {
            this.source = source;
        }

        public TResult Match<TResult>(TResult nothing, Func<T, TResult> just)
        {
            return source.Match(
                nothing: nothing,
                just: x => x.Match(
                    nothing: nothing,
                    just: just));
        }
    }
}
