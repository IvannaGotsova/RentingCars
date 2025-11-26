using RentingCars.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Core.Services.Comments
{
    public interface ICommentService
    {
        void AddComment(int carId, string content, string userName);
    }
}
