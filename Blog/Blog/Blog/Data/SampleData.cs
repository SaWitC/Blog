using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public static class SampleData
    {
        public static void Initialise(AplicationDbContext context)
        {
            if (!context.categories.Any())
            {
                context.categories.AddRange(
                    new Models.Category { Title = "Наука", Description = "Рассмотрение научного открытия или изобретения" },
                    new Models.Category { Title = "Видео игры", Description = "прохождение или гайд по видео игре" },
                    new Models.Category { Title = "Техника", Description = "Обзор новинок из мира техники." }
                    );
                context.SaveChanges();
            }
        }
    }
}
