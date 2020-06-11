using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace  WebApplication1.Helpers
{
    public class PagedList<T> : List<T>{

        public int currentPages{get;set;}
        public int totalPages {get;set;}
        public int pageSize{get;set;}
        public int totalCount { get;set;}

        public PagedList(List<T> items , int count , int pageNumber , int pageSize){
            totalCount = count;
            pageSize = pageSize;
            currentPages = pageNumber;
            totalPages = (int)Math.Ceiling(count/(double)pageSize);
            //if count will be 13 and page size is 5 then the result will be something 2.6 so it will return 3
            this.AddRanges(items);

        }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source , int pageNumber , 
        int pageSize){
            var count = await source.CountAsync();
            // if we have rquested for second page, then pagenumber = (2 -1) pagesize = 5
            // then first 5 data will get skip and we wll get next 5 data
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count , pageNumber , pageSize);
        }
        

    }
}