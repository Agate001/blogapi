using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogItemService _data;
    
    public BlogController(BlogItemService dataFromService)
    {
        _data = dataFromService;
    }

    [HttpPost("AddBlogItems")]
    public bool AddBlogItems(BlogItemModel newBlogItem)
    {
        return _data.AddBlogItems(newBlogItem);
    }
    public IEnumerable<BlogItemModel> GetAllBlogItems()
    {
        return _data.GetAllBlogItems();
    }
    [HttpGet("GetBlogItemsByCategoy/{category}")]

    public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
    {
        return _data.GetBlogItemsByCategory(category);
    }
    
    [HttpGet("GetItemsByTag/{Tag}")]

    public List<BlogItemModel> GetItemsByTag(string tag)
    {
        return _data.GetItemsByTag(tag);
    }
    
    [HttpGet("GetItemsByDate/{date}")]
    public IEnumerable<BlogItemModel>GetItemsByDate(string date)
    {
        return _data.GetItemsByDate(date);
    }

    [HttpPut("UpdateBlogItems")]

    public bool UpdateBlogItems(BlogItemModel blogupdate)
    {
        return _data.UpdateBlogItems(blogupdate);
    }

    [HttpPut("DeleteBlogItem/{BlogToDelete}")]

    public bool DeleteBlogItem(BlogItemModel BlogToDelete)
    {
        return _data.DeleteBlogItem(BlogToDelete);
    }

    [HttpGet("GetPublishedItems")]
    public IEnumerable<BlogItemModel> GetPublishedItems()
    {
        return _data.GetPublishedItems();
    }
    }
