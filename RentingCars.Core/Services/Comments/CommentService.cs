using RentingCars.Core.Services.ApplicationUsers;
using RentingCars.Data.Data;
using RentingCars.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Core.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextdata;
        private readonly IApplicationUserService applicationUserService;

        public CommentService(RentingCarsDbContext rentingCarsDbContextdata, 
            IApplicationUserService applicationUserService)
        {
            this.rentingCarsDbContextdata = rentingCarsDbContextdata;
            this.applicationUserService = applicationUserService;
        }

        public void AddComment(int carId, string content, string userName)
        {
            var comment = new Comment
            {
                CarId = carId,
                Content = content,
                CreatedAt = DateTime.Now,
                UserName = userName
            };

            rentingCarsDbContextdata.Comments.Add(comment);
            rentingCarsDbContextdata.SaveChanges();
        }
    }
}
