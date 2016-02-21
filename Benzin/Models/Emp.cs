using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benzin.Models
{
    public class Emp
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual DateTime payed_at { get; set; }
        public virtual int probeg { get; set; }
        public virtual int litrs { get; set; }
        public virtual decimal summa { get; set; }

        public virtual void Save()
        {
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            Benzin.Common.IRepository<Emp> repo = new Repositories.EmpRepository();

            repo.Save(this);
        }

        public virtual void Update()
        {
            this.updated_at = DateTime.Now;
            Benzin.Common.IRepository<Emp> repo = new Repositories.EmpRepository();
            repo.Update(this);
        }

        public static List<Emp> GetAll()
        {
            Benzin.Common.IRepository<Emp> repo = new Repositories.EmpRepository();
            return (List<Emp>)repo.GetAll();
        }

        public static Emp GetById(int ID)
        {
            Benzin.Common.IRepository<Emp> repo = new Repositories.EmpRepository();
            return repo.GetById(ID);
        }
        public virtual void Delete()
        {
            Benzin.Common.IRepository<Emp> repo = new Repositories.EmpRepository();
            repo.Delete(this);
        }

    }
}