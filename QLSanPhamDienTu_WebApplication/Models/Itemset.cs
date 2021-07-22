using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLSanPhamDienTu_WebApplication.Models
{
    public class Itemset : List<string>
    {
        public bool Contains(Itemset itemset)
        {
            return (this.Intersect(itemset).Count() == itemset.Count);
        }
        public Itemset Remove(Itemset itemset)
        {
            Itemset removed = new Itemset();
            removed.AddRange(from item in this
                             where !itemset.Contains(item)
                             select item);
            return (removed);
        }

        public string toString()
        {
            return string.Join(",", this.ToArray());
        }
    }
}