﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.PipelineFilter
{
    /// <summary>
    /// Taken from https://www.codeproject.com/Articles/1094513/Pipeline-and-Filters-Pattern-using-Csharp
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Pipeline<T>
    {
        /// <summary>
        /// List of filters in the pipeline
        /// </summary>
        protected readonly List<IFilter<T>> filters = new List<IFilter<T>>();

        /// <summary>
        /// To Register filter in the pipeline
        /// </summary>
        /// <param name="filter">A filter object implementing IFilter interface</param>
        /// <returns></returns>
        public Pipeline<T> Register(IFilter<T> filter)
        {
            filters.Add(filter);
            return this;
        }

        /// <summary>
        /// To start processing on the Pipeline
        /// </summary>
        /// <param name="input">
        /// The input object on which filter processing would execute</param>
        /// <returns></returns>
        public abstract T Process(T input);
    }
}
