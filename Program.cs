using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFQueryEntityFramework.Models;

namespace EFQueryEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            QuerryingAllEntities();
            FindingTheSingleEntity();
            ProjectionQuerries();
            QueryingNavigationalPropery();

        }


        static void QuerryingAllEntities()
        {

            //*************************************** QUERYING ALL ENTITIES *****************************

            //Query Syntax

            Console.WriteLine("Querying all Products using Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from e in db.Products
                               select e;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} ", p.ProductID, p.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //Method Syntax
            Console.WriteLine("Querying all products using Method Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = db.Products;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} ", p.ProductID, p.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //************************************** TOLIST Method ******************************************

            //Query Syntax
            Console.WriteLine("Querying all Products using Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = (from e in db.Products
                                select e).ToList();


                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} ", p.ProductID, p.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("Querying all products using Method Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = db.Products.ToList();

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} ", p.ProductID, p.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();




            //************************** FLITERING WITH WHERE CLAUSE ***********************************


            //Query Syntax
            Console.WriteLine("Filtering with Where Clause. Products staring with A.  Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from e in db.Products
                               where e.Name.StartsWith("A")
                               select e;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.ProductID, p.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //Method Syntax
            Console.WriteLine("Filtering with Where Clause. Products staring with A.  Method Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = db.Products.Where(e => e.Name.StartsWith("A"));

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.ProductID, p.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();








            //**********************************  SORTING ENTITIES *********************

            //Qury Syntax
            Console.WriteLine("Sortng on Product Name.  Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from p in db.Products
                               orderby p.Name
                               select p;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.Name, p.ProductNumber);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //****************************** SORTING Example 2

            Console.WriteLine("Sortng on Product Name.  Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from p in db.Products
                               orderby p.Name descending, p.ProductNumber, p.Color
                               select p;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.Name, p.ProductNumber);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //Method Syntax
            Console.WriteLine("Sortng on Product Name.  Method Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = db.Products.OrderBy(c => c.Name);

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.Name, p.ProductNumber);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //************************************ SORTING Example 3

            Console.WriteLine("Sortng on Product Name.  Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                var products = db.Products.OrderByDescending(c => c.Name).ThenBy(c => c.ProductNumber).ThenBy(c => c.Color);

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.Name, p.ProductNumber);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


        }


        static void FindingTheSingleEntity()
        {

            ////*************** FINDING THE SINGLE ENTITY


            ////PRIMARY KEY  *********************
            //Console.WriteLine("Finding the Entity using the Primary Key  Press Any key to continue");
            //Console.ReadLine();
            //using (AdventureWorks db = new AdventureWorks())
            //{
            //    var p = db.Products.Find(1);

            //    Console.WriteLine("{0}", p.Name);
            //}
            //Console.WriteLine("Press Any key to continue .... ");
            //Console.ReadLine();




            ////COMPOSIT PRIMARY KEY *********************
            //Console.WriteLine("Finding with Composite Primary Key.  Method Syntax.  Press Any key to continue");
            //Console.ReadLine();
            //using (AdventureWorks db = new AdventureWorks())
            //{
            //    var prdInv = db.ProductInventories.Find(1, 1);

            //    Console.WriteLine("{0} {1}", prdInv.ProductID, prdInv.LocationID);

            //}
            //Console.WriteLine("Press Any key to continue .... ");
            //Console.ReadLine();



            //***************************   SINGLE *************************************
            Console.WriteLine("SINGLE / Product Exists");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                try
                {
                    Product prd = db.Products.Single(p => p.Name == "Blade");
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("SINGLE /Product not exists / Exception is thrown");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.Single(p => p.Name == "Football");
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);
                }

            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("SINGLE /Multiple Records Exists / Exception will be thrown");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.Single(p => p.Name.StartsWith("A"));
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }

            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();






            //***************************   SINGLE OR DEFAULY*************************************
            Console.WriteLine("SingleOrDefault / Product Exists");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                try
                {
                    Product prd = db.Products.SingleOrDefault(p => p.Name == "Blade");
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("SingleOrDefault /Product not exists /Returns Default value (NULL)");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.SingleOrDefault<Product>(p => p.Name == "Football");
                    if (prd == null)
                    {
                        Console.WriteLine("Product not found");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);
                }

            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("SINGLE /Multiple Records Exists / Exception will be thrown");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.SingleOrDefault(p => p.Name.StartsWith("A"));
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }

            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();








            //***************************   First*************************************

            Console.WriteLine("First / Product Exists");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                try
                {
                    Product prd = db.Products.First(p => p.Name == "Blade");
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("First /Product not exists /Exception is thrown");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.First(p => p.Name == "Football");
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("First /Multiple Records Exists / First Record is returned");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.First(p => p.Name.StartsWith("A"));
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();





            //***************************   First or Default *************************************

            Console.WriteLine("FirstOrDefault / Product Exists");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                try
                {
                    Product prd = db.Products.FirstOrDefault(p => p.Name == "Blade");
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("First /Product not exists / Default Value is returned");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                try
                {
                    Product prd = db.Products.FirstOrDefault(p => p.Name == "Football");
                    if (prd == null)
                    {
                        Console.WriteLine("Product not found");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("First /Multiple Records Exists / First Record is returned");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {

                try
                {
                    Product prd = db.Products.FirstOrDefault(p => p.Name.StartsWith("A"));
                    Console.WriteLine("{0} {1}", prd.Name, prd.Color);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0}", e.Message);

                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


        }


        static void ProjectionQuerries()
        {


            Console.WriteLine("PROJECTION QUERRIES ");
            Console.ReadLine();
            
                     
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from e in db.Products
                               select e;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} {2} ", p.ProductID, p.Name , p.ListPrice);
                }
            }
            

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //Projecting to Annonymus Type  Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from p in db.Products select new { Name = p.Name, Price = p.ListPrice };
                               
                foreach (var p in products)
                {
                    Console.WriteLine("{0} {1} ", p.Name, p.Price);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //Projecting to Annonymus Type  (Method syntax)
            using (AdventureWorks db = new AdventureWorks())
            {
                var products = db.Products.Select(p => new { Name=p.Name,Price=p.ListPrice});

                foreach (var p in products)
                {
                    Console.WriteLine("{0} {1} ", p.Name, p.Price);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();




            //Projecting to Concrete Type
            using (AdventureWorks db = new AdventureWorks())
            {
                IEnumerable<customProduct> customProducts = from p in db.Products
                                       select new customProduct { Name = p.Name, Price = p.ListPrice };

                foreach (customProduct p in customProducts)
                {
                    Console.WriteLine("{0} {1} ", p.Name, p.Price);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //Projecting to Concrete Type  (Method syntax)
            using (AdventureWorks db = new AdventureWorks())
            {
                IEnumerable<customProduct> products = db.Products.Select(p => new customProduct { Name = p.Name, Price = p.ListPrice });
                
                
                foreach (customProduct p in products)
                {
                    Console.WriteLine("{0} {1} ", p.Name, p.Price);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();
        }



        private class customProduct {
                
            public string Name { get; set; }
            public decimal Price { get; set; }

        }

        



        static void QueryingNavigationalPropery()
        {

            Console.WriteLine("Press any key to Continue");
            Console.ReadLine();


            //**************************************************************************************************************
            //**************************************************************************************************************
            //**************************************************************************************************************
            //Many to One Relationship
            //One to One Relationship
            Console.WriteLine("Loading Related data using Navigational property");

            //Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var product = (from p in db.Products
                              where p.ProductID == 814
                               select p).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //**************************************************************************************************************
            //**************************************************************************************************************
            //**************************************************************************************************************
            //
            //Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from p in db.People
                              where p.FirstName == "KEN"
                              select p).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.BusinessEntityID, p.FirstName, p.MiddleName, p.LastName);

                    //Query is Fired to retreie the data from the table
                    foreach (var e in p.EmailAddresses)
                    {
                        Console.WriteLine(" ===============================> {0}", e.EmailAddress1);
                    }
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.People.Where(p => p.FirstName == "KEN").ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.BusinessEntityID, p.FirstName, p.MiddleName, p.LastName);
                    foreach (var e in p.EmailAddresses)
                    {
                        Console.WriteLine(" ===============================> {0}", e.EmailAddress1);
                    }
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();






            //*********************************************************************************************************************
            //************************************************  Include method  ***************************************************
            //*********************************************************************************************************************
            Console.WriteLine("Include method");
            //Query Syntax 
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from p in db.People.Include("EmailAddresses")
                              where p.FirstName == "KEN"
                              select p).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.BusinessEntityID, p.FirstName, p.MiddleName, p.LastName);
                    foreach (var e in p.EmailAddresses)
                    {
                        Console.WriteLine(" ===============================> {0}", e.EmailAddress1);
                    }
                }
            }


            //Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.People.Include("EmailAddresses").Where(p => p.FirstName == "KEN").ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.BusinessEntityID, p.FirstName, p.MiddleName, p.LastName);
                    foreach (var e in p.EmailAddresses)
                    {
                        Console.WriteLine(" ===============================> {0}", e.EmailAddress1);
                    }
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();











            //**********************************************************************************************************
            //*********************************************   Projection  **********************************************
            //**********************************************************************************************************
            Console.WriteLine("Projection");
            //************* Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from e in db.People
                              where e.FirstName == "KEN"            //??? && e.EmailAddresses != null
                              select new
                              {
                                  ID = e.BusinessEntityID,
                                  FirstName = e.FirstName,
                                  MiddleName = e.MiddleName,
                                  LastName = e.LastName,
                                  EmailAddresses = e.EmailAddresses
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} ", p.ID, p.FirstName, p.MiddleName, p.LastName);
                    foreach (var e in p.EmailAddresses)
                    {
                        Console.WriteLine("  =============================================> {0} ", e.EmailAddress1);
                    }
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.People.Where(p => p.FirstName == "KEN").Select(
                              p => new
                              {
                                  ID = p.BusinessEntityID,
                                  FirstName = p.FirstName,
                                  MiddleName = p.MiddleName,
                                  LastName = p.LastName,
                                  EmailAddresses = p.EmailAddresses
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} ", p.ID, p.FirstName, p.MiddleName, p.LastName);
                    foreach (var e in p.EmailAddresses)
                    {
                        Console.WriteLine("  =============================================> {0} ", e.EmailAddress1);
                    }
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //*********************************************************************************************************
            //****************************** Getting all the persons with email address *******************************
            //*********************************************************************************************************
            Console.WriteLine("Getting all the persons with email address");
            //************* Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from e in db.EmailAddresses
                              where e.Person.FirstName == "KEN"
                              select new
                              {
                                  ID = e.Person.BusinessEntityID,
                                  FirstName = e.Person.FirstName,
                                  MiddleName = e.Person.MiddleName,
                                  LastName = e.Person.LastName,
                                  EmailAddress1 = e.EmailAddress1
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.EmailAddress1);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.EmailAddresses
                             .Where(e => e.Person.FirstName == "KEN")
                             .Select(
                              e => new
                              {
                                  ID = e.Person.BusinessEntityID,
                                  FirstName = e.Person.FirstName,
                                  MiddleName = e.Person.MiddleName,
                                  LastName = e.Person.LastName,
                                  EmailAddress1 = e.EmailAddress1
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.EmailAddress1);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();




            //*************************************************************************************************************
            //*********************************************   Select Many  ************************************************
            //*************************************************************************************************************
            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.People.Where(p => p.FirstName == "KEN").SelectMany(
                              p => p.EmailAddresses,(p,e) => new
                              {
                                  ID = p.BusinessEntityID,
                                  FirstName = p.FirstName,
                                  MiddleName = p.MiddleName,
                                  LastName = p.LastName,
                                  EmailAddress1 = e.EmailAddress1
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} ", p.ID, p.FirstName, p.MiddleName, p.LastName, p.EmailAddress1);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //*************************************************************************************************************
            //*********************************************   Using Joins  ************************************************
            //*************************************************************************************************************
            Console.WriteLine("Using Joins");
            //Using Join Employee & Email Addresss  
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from p in db.People
                              join e in db.EmailAddresses
                              on p.BusinessEntityID equals e.BusinessEntityID
                              where p.FirstName == "KEN"
                              select new { ID = p.BusinessEntityID, FirstName = p.FirstName, MiddleName = p.MiddleName, LastName = p.LastName, EmailID = e.EmailAddress1 }).ToList();


                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.EmailID);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //********* Method Syntax Using Join
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.People
                             .Join(db.EmailAddresses, 
                                   p => p.BusinessEntityID, 
                                   e => e.BusinessEntityID,
                                  (p, e) => new { FirstName = p.FirstName, MiddleName = p.MiddleName, LastName = p.LastName, EmailID = e.EmailAddress1 }).Take(5);

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} Email ID : {3}", p.FirstName, p.MiddleName, p.LastName, p.EmailID);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();










            //**************************************************************************************************************
            //*******************************  Joining in one to One relationship ******************************************
            //**************************************************************************************************************
            //************* Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from e in db.Employees
                              join p in db.People on e.BusinessEntityID equals p.BusinessEntityID
                              join s in db.SalesPersons on e.BusinessEntityID equals s.BusinessEntityID
                              join t in db.SalesTerritories on s.TerritoryID equals t.TerritoryID 
                              where t.CountryRegionCode  == "CA"
                              select new
                              {
                                  ID = e.BusinessEntityID,
                                  FirstName = p.FirstName,
                                  MiddleName = p.MiddleName,
                                  LastName = p.LastName,
                                  Region = t.CountryRegionCode
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.Region);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.Employees
                             .Join(db.People, emp=> emp.BusinessEntityID, per=> per.BusinessEntityID,(emp,per) => new {emp,per})
                             .Join(db.SalesPersons, o => o.emp.BusinessEntityID, sal=> sal.BusinessEntityID , (emp1,sal) => new {emp1,sal})
                             .Join(db.SalesTerritories, o=> o.sal.TerritoryID, ter=>ter.TerritoryID, ( emp2, ter) => new {emp2,ter})
                             .Where(z => z.ter.CountryRegionCode=="CA")
                             .Select(z => new
                                {
                                    ID = z.emp2.emp1.per.BusinessEntityID,
                                    FirstName=z.emp2.emp1.per.FirstName,
                                    MiddleName=z.emp2.emp1.per.MiddleName,
                                    LastName=z.emp2.emp1.per.LastName,
                                    Region=z.ter.CountryRegionCode
                                }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.Region);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();



            //Using Navigational Property    
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = (from p in db.Employees
                              where p.SalesPerson.SalesTerritory.CountryRegionCode == "CA"
                              select new
                              {
                                  ID = p.BusinessEntityID,
                                  FirstName = p.Person.FirstName,
                                  MiddleName = p.Person.MiddleName,
                                  LastName = p.Person.LastName,
                                  Region = p.SalesPerson.SalesTerritory.CountryRegionCode
                              }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.Region);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


        }

    }
}



