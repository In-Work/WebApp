﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Test
{
    public class Comparer<T> : IEqualityComparer<T>
    {
        public static Comparer<T> GetComparer(Func<T, T, bool> func)
        {
            return new Comparer<T>(func);
        }

        private Func<T, T, bool> comparerFunction;

        public Comparer(Func<T, T, bool> func)
        {
            comparerFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return comparerFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
