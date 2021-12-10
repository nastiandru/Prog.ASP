using Prog_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Models
{
    public interface ICRUDBlogItemRepository
    {
        BlogItem Save(BlogItem item);

        void Delete(int id);

        BlogItem Update(BlogItem item);

        BlogItem FindById(int id);

        IList<BlogItem> FindAll();

        IList<BlogItem> FindPage(int page, int size);

        void addTagToBlogItem(int blogItemId, int tagId);

    }

    public void Delete(int id)
    {
        context.BlogItems.Remove(context.BlogItems.Find(id));
        context.SaveChanges();
    }

    public IList<BlogItem> FindAll()
    {
        return context.BlogItems.ToList();
    }
    public BlogItem FindById(int id)
    {
        context.Find(typeof(BlogItem), id);
        return context.BlogItems.ToFind();
    }

    public BlogItem Update(BlogItem item)
    {
        var entryEntity = context.BlogItems.Update(item);
        context.SaveChanges();
        return entryEntity.Entity;
    }


    public List<BlogItem> FindPage(int page, int size)
    {
        return (from item in context.BlogItems orderby item.CreationTimestamp select item)
            .Skip(page * size)
            .Take(size)
            .ToList();
    }
    public void addTagToBlogItem(int blogItemId, int tagId)
    {
        var item = context.BlogItems.Find(blogItemId);
        var tag = context.Tags.Find(tagId);
        item.Tags.Add(tag);
        Update(item);

    }

    public BlogItem Save(BlogItem item)
    {
        var entryEntity = context.BlogItems.Add(item);
        context.SaveChanges();
        return entryEntity.Entity;
    }

    
}
