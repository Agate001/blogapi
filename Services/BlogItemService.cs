using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Services.Context;

namespace blogapi.Services;

    public class BlogItemService
    {
        private readonly DataContext _context;
        public BlogItemService(DataContext context)
        {
            _context = context;
        }
        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            bool result;
            _context.Add(newBlogItem);
            result = _context.SaveChanges() != 0;
            return result;
        }

    public bool DeleteBlogItem(BlogItemModel blogToDelete)
    {
        _context.Update(blogToDelete);
        return _context.SaveChanges() != 0;
    }

    public IEnumerable<BlogItemModel> GetAllBlogItems()
    {
        return _context.BlogInfo;
    }

    public IEnumerable<BlogItemModel> GetBlogItemsByCategory(string category)
    {
        return _context.BlogInfo.Where(item => item.Category == category);
    }

    public IEnumerable<BlogItemModel> GetItemsByDate(string date)
    {
        return _context.BlogInfo.Where(item => item.Date == date);
    }

    public List<BlogItemModel> GetItemsByTag(string tag)
    {
        List<BlogItemModel> AllBlogWithTag = new List<BlogItemModel>();
        var allItems = GetAllBlogItems().ToList();


        for(int i = 0; i < allItems.Count; i++)
        {
            BlogItemModel Item = allItems[i];
            var itemArr = Item.Tags.Split(',');

            for (int j = 0; j < itemArr.Length; j++)
            {
                if (itemArr[j].Contains(tag))
                {
                    AllBlogWithTag.Add(Item);
                    break;
                }
            }
        }
        return AllBlogWithTag;
    }

    public bool UpdateBlogItems(BlogItemModel blogupdate)
    {
        _context.Update(blogupdate);
        return _context.SaveChanges() != 0;
    }

    public IEnumerable<BlogItemModel> GetPublishedItems()
    {
       return _context.BlogInfo.Where(item => item.isPublished);
    }
}
