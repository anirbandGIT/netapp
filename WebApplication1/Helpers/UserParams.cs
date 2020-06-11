using System;
using System.Collections.Generic;
using System.Linq;

namespace  WebApplication1.Helpers
{
    public class UserParams{
        private const int MaxSize = 100;
        public int pageNumber {get; set;}
        private int pageSize=10;
        public int PageSize {
            get { return pageSize;}
            set { pageSize = (value > MaxSize) ? MaxSize : value;}
        }


    }
}