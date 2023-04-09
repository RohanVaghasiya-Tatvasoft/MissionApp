using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionApp.Entities.ViewModels
{
    public class PaginationVM
    {
        public int TotalMissions { get; private set; }
        public int CurrentPage { get; private set;}
        public int PageSize { get; private set;}
        public int TotalPages { get; private set;}
        public int StartPage { get; private set;}
        public int EndPage { get; private set;}

        public PaginationVM()
        {
            
        }

        public PaginationVM(int totalMissions, int page, int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalMissions / (decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 2;
            int endPage = currentPage + 2;

            if(StartPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 5)
                {
                    startPage = endPage - 4;
                }
            }

            TotalMissions = totalMissions;
            CurrentPage = currentPage;
            StartPage = startPage;
            EndPage = endPage;
            TotalPages = totalPages;
            PageSize = pageSize;
        }
    }
}
