using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.ChurchEncoding
{
    public class MaybeSelected<T, TSelectResult> : IMaybe<TSelectResult>
    {
        private readonly IMaybe<T> source;
        private readonly Func<T, TSelectResult> selector;

        public MaybeSelected(
            IMaybe<T> source,
            Func<T, TSelectResult> selector)
        {
            this.source = source;
            this.selector = selector;
        }

        public TResult Match<TResult>(TResult nothing, Func<TSelectResult, TResult> just)
        {
            return source.Match(
                nothing: nothing,
                just: x => just(selector(x)));
        }
    }
}
