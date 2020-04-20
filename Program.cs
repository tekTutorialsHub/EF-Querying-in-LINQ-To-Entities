using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using EFQueryEntityFramework.Models;

namespace EFQueryEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            //https://www.tektutorialshub.com/entity-framework/querying-in-entity-framework/

            //QuerryingExample1();
            //QuerryingExampleToList();
            //QuerryingExampleWhereClause();
            //QuerryingExampleSorting();


            //https://www.tektutorialshub.com/entity-framework/single-singleordefault-first-firstordefault-in-entity-framework/

            //QueryExampleFindMethod();
            //QueryExampleSingleMethod();
            //QueryExampleSingleOrDefaultMethod();
            //QueryExampleFirstMethod();
            //QueryExampleFirstOrDefaultMethod();


            //https://www.tektutorialshub.com/entity-framework/projection-queries-in-entity-framework/

            //ProjectionExampleNoProjection();
            //ProjectionToAnnonymusType();
            //ProjectionToConcreteType();


            //https://www.tektutorialshub.com/entity-framework/join-query-entity-framework/

            //QueryJoin();
            //QueryJoinMultipleTablesQuerySyntax();
            //QueryJoinMultipleTablesMethodSyntax();
            //QueryJoinNavigationalProperty();
            //QueryJoinLeft();



            //https://www.tektutorialshub.com/entity-framework/entity-framework-include-method/

            //QueryingIncludeExample1();
            //QueryingIncludeExample2();
            //QueryingIncludeExample3();


            //https://www.tektutorialshub.com/linq-to-entities/entity-framework-loading-related-entities/

            //ueryingRelatedEntityExample1();
            //QueryingRelatedEntityExample2();
            //QueryingNavigationalProperyIncludeMethod();
            //QueryingRelatedEntityProjectionQuery1();
            //QueryingRelatedEntityProjectionQuery2();
            //QueryRelatedExplicitLoading();


            //https://www.tektutorialshub.com/entity-framework/ef-eager-loading/
            //QueryingEagerExample1();
            //QueryingEagerExample2();
            //QueryingEagerExample3();
            //QueryingEagerExample4();
            //QueryingEagerExample5();



            //https://www.tektutorialshub.com/entity-framework/ef-explicit-loading/
            //QueryingExpicitExample1();
            //QueryingExpicitExample2();
            //QueryingExpicitExample3();


            //SelectManyExample1();
            SelectManyExample2();
            //SelectManyExample3();
            SelectManyExample4();

        }


        //https://www.tektutorialshub.com/entity-framework/querying-in-entity-framework/

        static void QuerryingExample1()
        {

            //*************************************** QUERYING ALL ENTITIES *****************************

            //Query Syntax

            Console.WriteLine("Querying all Products using Query Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

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
        }

        static void QuerryingExampleToList()
        {


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

        }

        static void QuerryingExampleWhereClause()
        {



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

        }

        static void QuerryingExampleSorting()
        {

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



        //https://www.tektutorialshub.com/entity-framework/single-singleordefault-first-firstordefault-in-entity-framework/

        static void QueryExampleFindMethod()
        {

            //*************** FINDING THE SINGLE ENTITY


            //PRIMARY KEY  *********************
            Console.WriteLine("Finding the Entity using the Primary Key  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var p = db.Products.Find(1);

                Console.WriteLine("{0}", p.Name);
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();




            //COMPOSIT PRIMARY KEY *********************
            Console.WriteLine("Finding with Composite Primary Key.  Method Syntax.  Press Any key to continue");
            Console.ReadLine();
            using (AdventureWorks db = new AdventureWorks())
            {
                var prdInv = db.ProductInventories.Find(1, 1);

                Console.WriteLine("{0} {1}", prdInv.ProductID, prdInv.LocationID);

            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();
        }

        static void QueryExampleSingleMethod()
        {

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


        }

        static void QueryExampleSingleOrDefaultMethod()
        {

            //***************************   SINGLE OR DEFAULT*************************************
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

        }

        static void QueryExampleFirstMethod()
        {

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
        }

        static void QueryExampleFirstOrDefaultMethod()
        {

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



        //https://www.tektutorialshub.com/entity-framework/projection-queries-in-entity-framework/

        static void ProjectionExampleNoProjection()
        {

            Console.WriteLine("PROJECTION QUERRIES ");
            Console.ReadLine();


            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from e in db.Products
                               select e;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} {2} ", p.ProductID, p.Name, p.ListPrice);
                }
            }


            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();
        }

        static void ProjectionToAnnonymusType()
        {

            Console.WriteLine("PROJECTION QUERRIES ");
            Console.ReadLine();


            using (AdventureWorks db = new AdventureWorks())
            {
                var products = from e in db.Products
                               select e;

                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1} {2} ", p.ProductID, p.Name, p.ListPrice);
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
                var products = db.Products.Select(p => new { Name = p.Name, Price = p.ListPrice });

                foreach (var p in products)
                {
                    Console.WriteLine("{0} {1} ", p.Name, p.Price);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

        }

        static void ProjectionToConcreteType()
        {

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

        private class customProduct
        {

            public string Name { get; set; }
            public decimal Price { get; set; }

        }



        //https://www.tektutorialshub.com/entity-framework/join-query-entity-framework/

        static void QueryJoin()
        {

            //*************************************************************************************************************
            //*********************************************   Using Joins  ************************************************
            //*************************************************************************************************************
            Console.WriteLine("Using Joins");
            //Using Join Employee & Email Addresss  
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

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
                db.Database.Log = Console.Write;

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



        }

        static void QueryJoinMultipleTablesQuerySyntax()
        {

            //**************************************************************************************************************
            //*******************************  Joining multiple Table ******************************************
            //**************************************************************************************************************
            //************* Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

                var person = (from e in db.Employees
                              join p in db.People 
                              on e.BusinessEntityID equals p.BusinessEntityID
                              join s in db.SalesPersons 
                              on e.BusinessEntityID equals s.BusinessEntityID
                              join t in db.SalesTerritories 
                              on s.TerritoryID equals t.TerritoryID
                              where t.CountryRegionCode == "CA"
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

        }

        static void QueryJoinMultipleTablesMethodSyntax()
        {

            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

                var person = db.Employees
                                .Join(db.People,
                                    emp => emp.BusinessEntityID,
                                    per => per.BusinessEntityID,
                                    (emp, per) => new
                                    {
                                        emp.BusinessEntityID,
                                        per.FirstName,
                                        per.MiddleName,
                                        per.LastName
                                    })

                                .Join(db.SalesPersons,
                                    o => o.BusinessEntityID,
                                    sal => sal.BusinessEntityID,
                                    (o, sal) => new
                                    {
                                        o.BusinessEntityID,
                                        o.FirstName,
                                        o.MiddleName,
                                        o.LastName,
                                        sal.TerritoryID
                                    })

                                .Join(db.SalesTerritories,
                                    o => o.TerritoryID,
                                    ter => ter.TerritoryID,
                                    (o, ter) => new
                                    {
                                        o.BusinessEntityID,
                                        o.FirstName,
                                        o.MiddleName,
                                        o.LastName,
                                        o.TerritoryID,
                                        ter.CountryRegionCode
                                    })

                                .Where(r => r.CountryRegionCode == "CA")
                                .Select(r => new
                                {
                                    ID = r.BusinessEntityID,
                                    FirstName = r.FirstName,
                                    MiddleName = r.MiddleName,
                                    LastName = r.LastName,
                                    Region = r.CountryRegionCode
                                }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.Region);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();




            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

                var person = db.Employees
                             .Join(db.People,
                                    emp => emp.BusinessEntityID,
                                    per => per.BusinessEntityID,
                                    (emp, per) => new { emp, per })

                             .Join(db.SalesPersons,
                                    o => o.emp.BusinessEntityID,
                                    sal => sal.BusinessEntityID,
                                    (emp1, sal) => new { emp1, sal })

                             .Join(db.SalesTerritories,
                                    o => o.sal.TerritoryID,
                                    ter => ter.TerritoryID,
                                    (emp2, ter) => new { emp2, ter })

                             .Where(z => z.ter.CountryRegionCode == "CA")
                             .Select(z => new
                             {
                                 ID = z.emp2.emp1.per.BusinessEntityID,
                                 FirstName = z.emp2.emp1.per.FirstName,
                                 MiddleName = z.emp2.emp1.per.MiddleName,
                                 LastName = z.emp2.emp1.per.LastName,
                                 Region = z.ter.CountryRegionCode
                             }).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.Region);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

        }

        static void QueryJoinNavigationalProperty()
        {
            //Using Navigational Property    
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

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

        static void QueryJoinLeft()
        {


            Console.Clear();
            Console.WriteLine("Inner Join");

            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;


                var person = (from d in db.People
                              join e in db.EmailAddresses
                              on d.BusinessEntityID equals e.BusinessEntityID
                              select new
                              {
                                  FirstName = d.FirstName,
                                  MiddleName = d.MiddleName,
                                  LastName = d.LastName,
                                  Email = e.EmailAddress1
                              })
                                .Take(5)
                                .ToList();



                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.FirstName, p.MiddleName, p.LastName, p.Email);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            Console.WriteLine("Left Join");
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;


                var person = (from d in db.People
                              join e in db.EmailAddresses
                              on d.BusinessEntityID equals e.BusinessEntityID into j1

                              from r in j1.DefaultIfEmpty()

                                  // where e.FirstName.StartsWith("A")
                              select new
                              {
                                  FirstName = d.FirstName,
                                  MiddleName = d.MiddleName,
                                  LastName = d.LastName,
                                  Email = r.EmailAddress1
                              })
                                .Take(5)
                                .ToList();



                foreach (var p in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.FirstName, p.MiddleName, p.LastName, p.Email);
                }
            }


            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //Console.WriteLine("Method Syntax");

            //using (AdventureWorks db = new AdventureWorks())
            //{

            //    db.Database.Log = Console.Write;

            //    var person = db.Employees
            //                .Join(db.Departments,
            //                      e => e.DepartmentID,
            //                      d => d.DepartmentID,
            //                      (e, d) => new
            //                      {
            //                          FirstName = e.FirstName,
            //                          MiddleName = e.MiddleName,
            //                          LastName = e.LastName,
            //                          Department = d.Name
            //                      }
            //                      )
            //                    .Where(e => e.FirstName.StartsWith("B"))
            //                    .ToList();

            //    foreach (var p in person)
            //    {
            //        Console.WriteLine("{0} {1} {2} {3}", p.FirstName, p.MiddleName, p.LastName, p.Department);
            //    }
            //}

            //Console.WriteLine("Press Any key to continue .... ");
            //Console.ReadLine();


        }


        //https://www.tektutorialshub.com/linq-to-entities/entity-framework-loading-related-entities/

        static void QueryingRelatedEntityExample1()
        {

            Console.WriteLine("Loading Related data using Navigational property");

            //Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;


                var products = (from p in db.Products
                                where p.Name.StartsWith("A") & p.ProductModelID != null

                                select p    //new { p.ProductID, p.Name, p.ProductModel}
                                )
                                .Take(5)
                                .ToList();

                foreach (var p in products)
                {
                    Console.ReadLine();
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT TOP (5)
            //[Extent1].[ProductID] AS[ProductID],
            //[Extent1].[Name] AS[Name],
            //[Extent1].[ProductNumber] AS[ProductNumber],
            //[Extent1].[MakeFlag] AS[MakeFlag],
            //[Extent1].[FinishedGoodsFlag] AS[FinishedGoodsFlag],
            //[Extent1].[Color] AS[Color],
            //[Extent1].[SafetyStockLevel] AS[SafetyStockLevel],
            //[Extent1].[ReorderPoint] AS[ReorderPoint],
            //[Extent1].[StandardCost] AS[StandardCost],
            //[Extent1].[ListPrice] AS[ListPrice],
            //[Extent1].[Size] AS[Size],
            //[Extent1].[SizeUnitMeasureCode] AS[SizeUnitMeasureCode],
            //[Extent1].[WeightUnitMeasureCode] AS[WeightUnitMeasureCode],
            //[Extent1].[Weight] AS[Weight],
            //[Extent1].[DaysToManufacture] AS[DaysToManufacture],
            //[Extent1].[ProductLine] AS[ProductLine],
            //[Extent1].[Class] AS[Class],
            //[Extent1].[Style] AS[Style],
            //[Extent1].[ProductSubcategoryID] AS[ProductSubcategoryID],
            //[Extent1].[ProductModelID] AS[ProductModelID],
            //[Extent1].[SellStartDate] AS[SellStartDate],
            //[Extent1].[SellEndDate] AS[SellEndDate],
            //[Extent1].[DiscontinuedDate] AS[DiscontinuedDate],
            //[Extent1].[rowguid] AS[rowguid],
            //[Extent1].[ModifiedDate] AS[ModifiedDate]
            //FROM[Production].[Product] AS[Extent1]
            //WHERE([Extent1].[Name] LIKE N'A%') AND([Extent1].[ProductModelID] IS NOT NULL)


            //SELECT
            //[Extent1].[ProductModelID] AS[ProductModelID],
            //[Extent1].[Name]
            //AS[Name],
            //[Extent1].[CatalogDescription]
            //AS[CatalogDescription],
            //[Extent1].[Instructions]
            //AS[Instructions],
            //[Extent1].[rowguid]
            //AS[rowguid],
            //[Extent1].[ModifiedDate]
            //AS[ModifiedDate]
            //FROM[Production].[ProductModel]
            //AS[Extent1]
            //WHERE[Extent1].[ProductModelID] = @EntityKeyValue1

        }

        static void QueryingRelatedEntityExample2()
        {

            //Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;
                db.Configuration.LazyLoadingEnabled = false;

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
                db.Database.Log = Console.Write;

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

            //SELECT
            //[Extent1].[BusinessEntityID] AS [BusinessEntityID],
            //[Extent1].[PersonType] AS [PersonType],
            //[Extent1].[NameStyle] AS [NameStyle],
            //[Extent1].[Title] AS [Title],
            //[Extent1].[FirstName] AS [FirstName],
            //[Extent1].[MiddleName] AS [MiddleName],
            //[Extent1].[LastName] AS [LastName],
            //[Extent1].[Suffix] AS [Suffix],
            //[Extent1].[EmailPromotion] AS [EmailPromotion],
            //[Extent1].[AdditionalContactInfo] AS [AdditionalContactInfo],
            //[Extent1].[Demographics] AS [Demographics],
            //[Extent1].[rowguid] AS [rowguid],
            //[Extent1].[ModifiedDate] AS [ModifiedDate]
            //FROM [Person].[Person] AS [Extent1]
            //WHERE N'KEN' = [Extent1].[FirstName]


            //SELECT
            //[Extent1].[BusinessEntityID] AS [BusinessEntityID],
            //[Extent1].[EmailAddressID] AS [EmailAddressID],
            //[Extent1].[EmailAddress] AS [EmailAddress],
            //[Extent1].[rowguid] AS [rowguid],
            //[Extent1].[ModifiedDate] AS [ModifiedDate]
            //FROM [Person].[EmailAddress] AS [Extent1]
            //WHERE [Extent1].[BusinessEntityID] = @EntityKeyValue1


        }

        static void QueryingNavigationalProperyIncludeMethod()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            //*********************************************************************************************************************
            //************************************************  Include method  ***************************************************
            //*********************************************************************************************************************
            Console.WriteLine("Include method");
            //Query Syntax 
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

                var person = (from p in db.People.Include(p => p.EmailAddresses)
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

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

                var person = db.People
                        .Include(p => p.EmailAddresses)
                        .Where(p => p.FirstName == "KEN").ToList();

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

            //SELECT
            //[Project1].[BusinessEntityID] AS [BusinessEntityID],
            //[Project1].[PersonType] AS [PersonType],
            //[Project1].[NameStyle] AS [NameStyle],
            //[Project1].[Title] AS [Title],
            //[Project1].[FirstName] AS [FirstName],
            //[Project1].[MiddleName] AS [MiddleName],
            //[Project1].[LastName] AS [LastName],
            //[Project1].[Suffix] AS [Suffix],
            //[Project1].[EmailPromotion] AS [EmailPromotion],
            //[Project1].[AdditionalContactInfo] AS [AdditionalContactInfo],
            //[Project1].[Demographics] AS [Demographics],
            //[Project1].[rowguid] AS [rowguid],
            //[Project1].[ModifiedDate] AS [ModifiedDate],
            //[Project1].[C1] AS [C1],
            //[Project1].[BusinessEntityID1] AS [BusinessEntityID1],
            //[Project1].[EmailAddressID] AS [EmailAddressID],
            //[Project1].[EmailAddress] AS [EmailAddress],
            //[Project1].[rowguid1] AS [rowguid1],
            //[Project1].[ModifiedDate1] AS [ModifiedDate1]
            //FROM ( SELECT
            //    [Extent1].[BusinessEntityID] AS [BusinessEntityID],
            //    [Extent1].[PersonType] AS [PersonType],
            //    [Extent1].[NameStyle] AS [NameStyle],
            //    [Extent1].[Title] AS [Title],
            //    [Extent1].[FirstName] AS [FirstName],
            //    [Extent1].[MiddleName] AS [MiddleName],
            //    [Extent1].[LastName] AS [LastName],
            //    [Extent1].[Suffix] AS [Suffix],
            //    [Extent1].[EmailPromotion] AS [EmailPromotion],
            //    [Extent1].[AdditionalContactInfo] AS [AdditionalContactInfo],
            //    [Extent1].[Demographics] AS [Demographics],
            //    [Extent1].[rowguid] AS [rowguid],
            //    [Extent1].[ModifiedDate] AS [ModifiedDate],
            //    [Extent2].[BusinessEntityID] AS [BusinessEntityID1],
            //    [Extent2].[EmailAddressID] AS [EmailAddressID],
            //    [Extent2].[EmailAddress] AS [EmailAddress],
            //    [Extent2].[rowguid] AS [rowguid1],
            //    [Extent2].[ModifiedDate] AS [ModifiedDate1],
            //    CASE WHEN ([Extent2].[BusinessEntityID] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
            //    FROM  [Person].[Person] AS [Extent1]
            //    LEFT OUTER JOIN [Person].[EmailAddress] AS [Extent2] ON [Extent1].[BusinessEntityID] = [Extent2].[BusinessEntityID]
            //    WHERE N'KEN' = [Extent1].[FirstName]
            //)  AS [Project1]
            //ORDER BY [Project1].[BusinessEntityID] ASC, [Project1].[C1] ASC



        }

        static void QueryingRelatedEntityProjectionQuery1()
        {

            Console.WriteLine("Loading Related data using Projection Query");

            //Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;

                var products = (from p in db.Products
                                where p.Name.StartsWith("A") & p.ProductModelID != null

                                select new { p.ProductID, p.Name, p.ProductModel }
                                )
                                .Take(5)
                                .ToList();

                foreach (var p in products)
                {
                    Console.ReadLine();
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();


            //SELECT TOP (5)
            //[Extent1].[ProductID] AS[ProductID], [Extent1].[Name] AS[Name],
            //[Extent2].[ProductModelID] AS[ProductModelID], [Extent2].[Name] AS[Name1],
            //[Extent2].[CatalogDescription] AS[CatalogDescription], [Extent2].[Instructions] AS[Instructions], [Extent2].[rowguid] AS[rowguid],
            //[Extent2].[ModifiedDate] AS[ModifiedDate]
            //FROM[Production].[Product] AS[Extent1]
            //LEFT OUTER JOIN[Production].[ProductModel] AS[Extent2] ON[Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //WHERE([Extent1].[Name] LIKE N'A%') AND([Extent1].[ProductModelID] IS NOT NULL)


        }

        static void QueryingRelatedEntityProjectionQuery2()
        {

            Console.WriteLine("Loading Related data using Projection Query");

            //Query Syntax
            using (AdventureWorks db = new AdventureWorks())
            {

                db.Database.Log = Console.Write;

                var person = (from e in db.People
                              where e.FirstName == "KEN"
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
                        Console.WriteLine("\t\t{0}", e.EmailAddress1);
                    }
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            using (AdventureWorks db = new AdventureWorks())
            {

                db.Database.Log = Console.Write;

                var person = db.People
                               .Where(p => p.FirstName == "KEN")
                               .Select(p => new
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
                        Console.WriteLine("\t\t{0}", e.EmailAddress1);
                    }
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT
            //[Project1].[BusinessEntityID] AS [BusinessEntityID],
            //[Project1].[FirstName] AS [FirstName],
            //[Project1].[MiddleName] AS [MiddleName],
            //[Project1].[LastName] AS [LastName],
            //[Project1].[C1] AS [C1],
            //[Project1].[BusinessEntityID1] AS [BusinessEntityID1],
            //[Project1].[EmailAddressID] AS [EmailAddressID],
            //[Project1].[EmailAddress] AS [EmailAddress],
            //[Project1].[rowguid] AS [rowguid],
            //[Project1].[ModifiedDate] AS [ModifiedDate]
            //FROM ( SELECT
            //    [Extent1].[BusinessEntityID] AS [BusinessEntityID],
            //    [Extent1].[FirstName] AS [FirstName],
            //    [Extent1].[MiddleName] AS [MiddleName],
            //    [Extent1].[LastName] AS [LastName],
            //    [Extent2].[BusinessEntityID] AS [BusinessEntityID1],
            //    [Extent2].[EmailAddressID] AS [EmailAddressID],
            //    [Extent2].[EmailAddress] AS [EmailAddress],
            //    [Extent2].[rowguid] AS [rowguid],
            //    [Extent2].[ModifiedDate] AS [ModifiedDate],
            //    CASE WHEN ([Extent2].[BusinessEntityID] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
            //    FROM  [Person].[Person] AS [Extent1]
            //    LEFT OUTER JOIN [Person].[EmailAddress] AS [Extent2] ON [Extent1].[BusinessEntityID] = [Extent2].[BusinessEntityID]
            //    WHERE N'KEN' = [Extent1].[FirstName]
            //)  AS [Project1]


        }

        static void QueryRelatedExplicitLoading()
        {

            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                //List of Products queried here.
                var product = (from p in db.Products
                               orderby p.ProductID descending
                               select p).Take(5).ToList();

                foreach (var p in product)
                {
                    //Product model is retrieved here
                    db.Entry(p).Reference(m => m.ProductModel).Load();
                    Console.WriteLine("{0} {1} Product Model => {2}", p.ProductID, p.Name, (p.ProductModel == null) ? "" : p.ProductModel.Name);
                    Console.ReadKey();
                }
            }
        }



        //Include

        static void QueryingIncludeExample1()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var product = (from p in db.Products
                                .Include(p => p.ProductModel) // Reference Property
                               where p.ProductID == 814
                               select p).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT
            //[Extent1].[ProductID] AS [ProductID],
            //[Extent1].[Name] AS [Name],
            //[Extent1].[ProductNumber] AS [ProductNumber],
            //[Extent1].[MakeFlag] AS [MakeFlag],
            //[Extent1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //[Extent1].[Color] AS [Color],
            //[Extent1].[SafetyStockLevel] AS [SafetyStockLevel],
            //[Extent1].[ReorderPoint] AS [ReorderPoint],
            //[Extent1].[StandardCost] AS [StandardCost],
            //[Extent1].[ListPrice] AS [ListPrice],
            //[Extent1].[Size] AS [Size],
            //[Extent1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //[Extent1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //[Extent1].[Weight] AS [Weight],
            //[Extent1].[DaysToManufacture] AS [DaysToManufacture],
            //[Extent1].[ProductLine] AS [ProductLine],
            //[Extent1].[Class] AS [Class],
            //[Extent1].[Style] AS [Style],
            //[Extent1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //[Extent1].[ProductModelID] AS [ProductModelID],
            //[Extent1].[SellStartDate] AS [SellStartDate],
            //[Extent1].[SellEndDate] AS [SellEndDate],
            //[Extent1].[DiscontinuedDate] AS [DiscontinuedDate],
            //[Extent1].[rowguid] AS [rowguid],
            //[Extent1].[ModifiedDate] AS [ModifiedDate],
            //[Extent2].[ProductModelID] AS [ProductModelID1],
            //[Extent2].[Name] AS [Name1],
            //[Extent2].[CatalogDescription] AS [CatalogDescription],
            //[Extent2].[Instructions] AS [Instructions],
            //[Extent2].[rowguid] AS [rowguid1],
            //[Extent2].[ModifiedDate] AS [ModifiedDate1]
            //FROM  [Production].[Product] AS [Extent1]
            //LEFT OUTER JOIN [Production].[ProductModel] AS [Extent2] ON [Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //WHERE 814 = [Extent1].[ProductID]

        }

        static void QueryingIncludeExample2()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var models = (from p in db.ProductModels
                                .Include(p => p.Products) //Collection
                              where p.Name == "Classic Vest"
                              select p).ToList();

                foreach (var p in models)
                {
                    Console.WriteLine("{0}", p.Name);

                    foreach (var product in p.Products)
                    {
                        Console.WriteLine("\t\t{0} {1}", product.ProductID, product.Name);
                    }
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT
            //    [Project1].[ProductModelID] AS [ProductModelID],
            //    [Project1].[Name] AS [Name],
            //    [Project1].[CatalogDescription] AS [CatalogDescription],
            //    [Project1].[Instructions] AS [Instructions],
            //    [Project1].[rowguid] AS [rowguid],
            //    [Project1].[ModifiedDate] AS [ModifiedDate],
            //    [Project1].[C1] AS [C1],
            //    [Project1].[ProductID] AS [ProductID],
            //    [Project1].[Name1] AS [Name1],
            //    [Project1].[ProductNumber] AS [ProductNumber],
            //    [Project1].[MakeFlag] AS [MakeFlag],
            //    [Project1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //    [Project1].[Color] AS [Color],
            //    [Project1].[SafetyStockLevel] AS [SafetyStockLevel],
            //    [Project1].[ReorderPoint] AS [ReorderPoint],
            //    [Project1].[StandardCost] AS [StandardCost],
            //    [Project1].[ListPrice] AS [ListPrice],
            //    [Project1].[Size] AS [Size],
            //    [Project1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //    [Project1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //    [Project1].[Weight] AS [Weight],
            //    [Project1].[DaysToManufacture] AS [DaysToManufacture],
            //    [Project1].[ProductLine] AS [ProductLine],
            //    [Project1].[Class] AS [Class],
            //    [Project1].[Style] AS [Style],
            //    [Project1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //    [Project1].[ProductModelID1] AS [ProductModelID1],
            //    [Project1].[SellStartDate] AS [SellStartDate],
            //    [Project1].[SellEndDate] AS [SellEndDate],
            //    [Project1].[DiscontinuedDate] AS [DiscontinuedDate],
            //    [Project1].[rowguid1] AS [rowguid1],
            //    [Project1].[ModifiedDate1] AS [ModifiedDate1]
            //    FROM ( SELECT
            //        [Extent1].[ProductModelID] AS [ProductModelID],
            //        [Extent1].[Name] AS [Name],
            //        [Extent1].[CatalogDescription] AS [CatalogDescription],
            //        [Extent1].[Instructions] AS [Instructions],
            //        [Extent1].[rowguid] AS [rowguid],
            //        [Extent1].[ModifiedDate] AS [ModifiedDate],
            //        [Extent2].[ProductID] AS [ProductID],
            //        [Extent2].[Name] AS [Name1],
            //        [Extent2].[ProductNumber] AS [ProductNumber],
            //        [Extent2].[MakeFlag] AS [MakeFlag],
            //        [Extent2].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //        [Extent2].[Color] AS [Color],
            //        [Extent2].[SafetyStockLevel] AS [SafetyStockLevel],
            //        [Extent2].[ReorderPoint] AS [ReorderPoint],
            //        [Extent2].[StandardCost] AS [StandardCost],
            //        [Extent2].[ListPrice] AS [ListPrice],
            //        [Extent2].[Size] AS [Size],
            //        [Extent2].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //        [Extent2].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //        [Extent2].[Weight] AS [Weight],
            //        [Extent2].[DaysToManufacture] AS [DaysToManufacture],
            //        [Extent2].[ProductLine] AS [ProductLine],
            //        [Extent2].[Class] AS [Class],
            //        [Extent2].[Style] AS [Style],
            //        [Extent2].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //        [Extent2].[ProductModelID] AS [ProductModelID1],
            //        [Extent2].[SellStartDate] AS [SellStartDate],
            //        [Extent2].[SellEndDate] AS [SellEndDate],
            //        [Extent2].[DiscontinuedDate] AS [DiscontinuedDate],
            //        [Extent2].[rowguid] AS [rowguid1],
            //        [Extent2].[ModifiedDate] AS [ModifiedDate1],
            //        CASE WHEN ([Extent2].[ProductID] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
            //        FROM  [Production].[ProductModel] AS [Extent1]
            //        LEFT OUTER JOIN [Production].[Product] AS [Extent2] ON [Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //        WHERE N'Classic Vest' = [Extent1].[Name]
            //    )  AS [Project1]
            //    ORDER BY [Project1].[ProductModelID] ASC, [Project1].[C1] ASC

        }

        static void QueryingIncludeExample3()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_

            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var product = (from p in db.Products
                                .Include(p => p.ProductModel)
                                .Include(p => p.ProductSubcategory)
                                .Include(p => p.UnitMeasure)
                               where p.UnitMeasure != null
                               select p).Take(5).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ProductID, p.Name, p.ProductModel.Name, p.ProductSubcategory.Name, p.UnitMeasure.Name);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT TOP (5)
            //    [Extent1].[ProductID] AS [ProductID],
            //    [Extent1].[Name] AS [Name],
            //    [Extent1].[ProductNumber] AS [ProductNumber],
            //    [Extent1].[MakeFlag] AS [MakeFlag],
            //    [Extent1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //    [Extent1].[Color] AS [Color],
            //    [Extent1].[SafetyStockLevel] AS [SafetyStockLevel],
            //    [Extent1].[ReorderPoint] AS [ReorderPoint],
            //    [Extent1].[StandardCost] AS [StandardCost],
            //    [Extent1].[ListPrice] AS [ListPrice],
            //    [Extent1].[Size] AS [Size],
            //    [Extent1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //    [Extent1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //    [Extent1].[Weight] AS [Weight],
            //    [Extent1].[DaysToManufacture] AS [DaysToManufacture],
            //    [Extent1].[ProductLine] AS [ProductLine],
            //    [Extent1].[Class] AS [Class],
            //    [Extent1].[Style] AS [Style],
            //    [Extent1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //    [Extent1].[ProductModelID] AS [ProductModelID],
            //    [Extent1].[SellStartDate] AS [SellStartDate],
            //    [Extent1].[SellEndDate] AS [SellEndDate],
            //    [Extent1].[DiscontinuedDate] AS [DiscontinuedDate],
            //    [Extent1].[rowguid] AS [rowguid],
            //    [Extent1].[ModifiedDate] AS [ModifiedDate],
            //    [Extent2].[ProductModelID] AS [ProductModelID1],
            //    [Extent2].[Name] AS [Name1],
            //    [Extent2].[CatalogDescription] AS [CatalogDescription],
            //    [Extent2].[Instructions] AS [Instructions],
            //    [Extent2].[rowguid] AS [rowguid1],
            //    [Extent2].[ModifiedDate] AS [ModifiedDate1],
            //    [Extent3].[ProductSubcategoryID] AS [ProductSubcategoryID1],
            //    [Extent3].[ProductCategoryID] AS [ProductCategoryID],
            //    [Extent3].[Name] AS [Name2],
            //    [Extent3].[rowguid] AS [rowguid2],
            //    [Extent3].[ModifiedDate] AS [ModifiedDate2],
            //    [Extent4].[UnitMeasureCode] AS [UnitMeasureCode],
            //    [Extent4].[Name] AS [Name3],
            //    [Extent4].[ModifiedDate] AS [ModifiedDate3]
            //    FROM    [Production].[Product] AS [Extent1]
            //    LEFT OUTER JOIN [Production].[ProductModel] AS [Extent2] ON [Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //    LEFT OUTER JOIN [Production].[ProductSubcategory] AS [Extent3] ON [Extent1].[ProductSubcategoryID] = [Extent3].[ProductSubcategoryID]
            //    LEFT OUTER JOIN [Production].[UnitMeasure] AS [Extent4] ON [Extent1].[SizeUnitMeasureCode] = [Extent4].[UnitMeasureCode]
            //    WHERE [Extent1].[SizeUnitMeasureCode] IS NOT NULL

        }

        static void QueryingIncludeExample4()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_

            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var person = (from p in db.SalesPersons
                                .Include(p => p.Employee.Person)
                              select p).Take(5).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0}", p.Employee.Person.FirstName);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT TOP (5)
            //    [Extent1].[BusinessEntityID] AS [BusinessEntityID],
            //    [Extent1].[TerritoryID] AS [TerritoryID],
            //    [Extent1].[SalesQuota] AS [SalesQuota],
            //    [Extent1].[Bonus] AS [Bonus],
            //    [Extent1].[CommissionPct] AS [CommissionPct],
            //    [Extent1].[SalesYTD] AS [SalesYTD],
            //    [Extent1].[SalesLastYear] AS [SalesLastYear],
            //    [Extent1].[rowguid] AS [rowguid],
            //    [Extent1].[ModifiedDate] AS [ModifiedDate],
            //    [Extent2].[BusinessEntityID] AS [BusinessEntityID1],
            //    [Extent2].[NationalIDNumber] AS [NationalIDNumber],
            //    [Extent2].[LoginID] AS [LoginID],
            //    [Extent2].[OrganizationLevel] AS [OrganizationLevel],
            //    [Extent2].[JobTitle] AS [JobTitle],
            //    [Extent2].[BirthDate] AS [BirthDate],
            //    [Extent2].[MaritalStatus] AS [MaritalStatus],
            //    [Extent2].[Gender] AS [Gender],
            //    [Extent2].[HireDate] AS [HireDate],
            //    [Extent2].[SalariedFlag] AS [SalariedFlag],
            //    [Extent2].[VacationHours] AS [VacationHours],
            //    [Extent2].[SickLeaveHours] AS [SickLeaveHours],
            //    [Extent2].[CurrentFlag] AS [CurrentFlag],
            //    [Extent2].[rowguid] AS [rowguid1],
            //    [Extent2].[ModifiedDate] AS [ModifiedDate1],
            //    [Join2].[BusinessEntityID1] AS [BusinessEntityID2],
            //    [Join2].[PersonType] AS [PersonType],
            //    [Join2].[NameStyle] AS [NameStyle],
            //    [Join2].[Title] AS [Title],
            //    [Join2].[FirstName] AS [FirstName],
            //    [Join2].[MiddleName] AS [MiddleName],
            //    [Join2].[LastName] AS [LastName],
            //    [Join2].[Suffix] AS [Suffix],
            //    [Join2].[EmailPromotion] AS [EmailPromotion],
            //    [Join2].[AdditionalContactInfo] AS [AdditionalContactInfo],
            //    [Join2].[Demographics] AS [Demographics],
            //    [Join2].[rowguid1] AS [rowguid2],
            //    [Join2].[ModifiedDate1] AS [ModifiedDate2]
            //    FROM   [Sales].[SalesPerson] AS [Extent1]
            //    INNER JOIN [HumanResources].[Employee] AS [Extent2] ON [Extent1].[BusinessEntityID] = [Extent2].[BusinessEntityID]
            //    LEFT OUTER JOIN  (SELECT [Extent3].[BusinessEntityID] AS [BusinessEntityID1], [Extent3].[PersonType] AS [PersonType], [Extent3].[NameStyle] AS [NameStyle], [Extent3].[Title] AS [Title], [Extent3].[FirstName] AS [FirstName], [Extent3].[MiddleName] AS [MiddleName], [Extent3].[LastName] AS [LastName], [Extent3].[Suffix] AS [Suffix], [Extent3].[EmailPromotion] AS [EmailPromotion], [Extent3].[AdditionalContactInfo] AS [AdditionalContactInfo], [Extent3].[Demographics] AS [Demographics], [Extent3].[rowguid] AS [rowguid1], [Extent3].[ModifiedDate] AS [ModifiedDate1], [Extent4].[BusinessEntityID] AS [BusinessEntityID2]
            //        FROM  [Person].[Person] AS [Extent3]
            //        LEFT OUTER JOIN [HumanResources].[Employee] AS [Extent4] ON [Extent3].[BusinessEntityID] = [Extent4].[BusinessEntityID] ) AS [Join2] ON [Extent1].[BusinessEntityID] = [Join2].[BusinessEntityID2]

        }


        //SelectMany

        static void SelectManyExample1()
        {

            //Select a.name as ProductModel, b.productID, b.Name from
            //Production.ProductModel a
            //inner join[Production].[Product]                  b
            //on(a.ProductModelID= b.ProductModelID)
            //where a.Name like 'C%'

            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;


                var model = db.ProductModels
                                .Where(m => m.Name.StartsWith("C"))
                                .Select(m =>
                                        new
                                        {
                                            m.Name,
                                            m.Products
                                        }
                                    ).ToList();



                foreach (var p in model)
                {
                    Console.WriteLine("{0}", p.Name);

                    foreach (var prd in p.Products)
                    {
                        Console.WriteLine("\t\t{0}", prd.Name);
                    }
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT
            //    [Project1].[ProductModelID] AS [ProductModelID],
            //    [Project1].[Name] AS [Name],
            //    [Project1].[C1] AS [C1],
            //    [Project1].[ProductID] AS [ProductID],
            //    [Project1].[Name1] AS [Name1],
            //    [Project1].[ProductNumber] AS [ProductNumber],
            //    [Project1].[MakeFlag] AS [MakeFlag],
            //    [Project1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //    [Project1].[Color] AS [Color],
            //    [Project1].[SafetyStockLevel] AS [SafetyStockLevel],
            //    [Project1].[ReorderPoint] AS [ReorderPoint],
            //    [Project1].[StandardCost] AS [StandardCost],
            //    [Project1].[ListPrice] AS [ListPrice],
            //    [Project1].[Size] AS [Size],
            //    [Project1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //    [Project1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //    [Project1].[Weight] AS [Weight],
            //    [Project1].[DaysToManufacture] AS [DaysToManufacture],
            //    [Project1].[ProductLine] AS [ProductLine],
            //    [Project1].[Class] AS [Class],
            //    [Project1].[Style] AS [Style],
            //    [Project1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //    [Project1].[ProductModelID1] AS [ProductModelID1],
            //    [Project1].[SellStartDate] AS [SellStartDate],
            //    [Project1].[SellEndDate] AS [SellEndDate],
            //    [Project1].[DiscontinuedDate] AS [DiscontinuedDate],
            //    [Project1].[rowguid] AS [rowguid],
            //    [Project1].[ModifiedDate] AS [ModifiedDate]
            //    FROM ( SELECT
            //        [Extent1].[ProductModelID] AS [ProductModelID],
            //        [Extent1].[Name] AS [Name],
            //        [Extent2].[ProductID] AS [ProductID],
            //        [Extent2].[Name] AS [Name1],
            //        [Extent2].[ProductNumber] AS [ProductNumber],
            //        [Extent2].[MakeFlag] AS [MakeFlag],
            //        [Extent2].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //        [Extent2].[Color] AS [Color],
            //        [Extent2].[SafetyStockLevel] AS [SafetyStockLevel],
            //        [Extent2].[ReorderPoint] AS [ReorderPoint],
            //        [Extent2].[StandardCost] AS [StandardCost],
            //        [Extent2].[ListPrice] AS [ListPrice],
            //        [Extent2].[Size] AS [Size],
            //        [Extent2].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //        [Extent2].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //        [Extent2].[Weight] AS [Weight],
            //        [Extent2].[DaysToManufacture] AS [DaysToManufacture],
            //        [Extent2].[ProductLine] AS [ProductLine],
            //        [Extent2].[Class] AS [Class],
            //        [Extent2].[Style] AS [Style],
            //        [Extent2].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //        [Extent2].[ProductModelID] AS [ProductModelID1],
            //        [Extent2].[SellStartDate] AS [SellStartDate],
            //        [Extent2].[SellEndDate] AS [SellEndDate],
            //        [Extent2].[DiscontinuedDate] AS [DiscontinuedDate],
            //        [Extent2].[rowguid] AS [rowguid],
            //        [Extent2].[ModifiedDate] AS [ModifiedDate],
            //        CASE WHEN ([Extent2].[ProductID] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
            //        FROM  [Production].[ProductModel] AS [Extent1]
            //        LEFT OUTER JOIN [Production].[Product] AS [Extent2] ON [Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //        WHERE N'Classic Vest' = [Extent1].[Name]
            //    )  AS [Project1]
            //    ORDER BY [Project1].[ProductModelID] ASC, [Project1].[C1] ASC



        }

        static void SelectManyExample2()
        {

            //*************************************************************************************************************
            //*********************************************   Select Many  ************************************************
            //*************************************************************************************************************
            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;


                var model = db.ProductModels
                                .Where(m=> m.Name.StartsWith("C"))
                                .SelectMany(
                                    p => p.Products, (m, p) => new
                                    {
                                        ModelName= m.Name,
                                        ProductID = p.ProductID,
                                        ProductName=p.Name
                                    }).ToList();

                foreach (var p in model)
                {
                    Console.WriteLine("{0} {1} {2}", p.ModelName, p.ProductID, p.ProductName);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

        }

        static void SelectManyExample3()
        {

            //*************************************************************************************************************
            //*********************************************   Select Many  ************************************************
            //*************************************************************************************************************
            //************* Method Syntax
            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = sql => System.Diagnostics.Debug.Write(sql);

                var person = db.People.Where(p => p.FirstName == "KEN").SelectMany(
                              p => p.EmailAddresses, (p, e) => new
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

        }

        static void SelectManyExample4()
        {


            using (AdventureWorks db = new AdventureWorks())
            {
                db.Database.Log = Console.Write;


                var model = db.ProductModels
                                .Where(m => m.Name.StartsWith("C"))
                                .SelectMany(
                                    p => p.Products, (m, p) => new
                                    {
                                        ModelName = m.Name,
                                        ProductID = p.ProductID,
                                        ProductName = p.Name,
                                        p.ProductInventories
                                    })
                                    .SelectMany(p => p.ProductInventories, (m, p) => new
                                    {
                                        m.ModelName,
                                        m.ProductID,
                                        m.ProductName,
                                        p.LocationID,
                                        p.Quantity
                                    }).ToList();

                foreach (var p in model)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.ModelName, p.ProductID, p.ProductName,p.LocationID, p.Quantity);
                }
            }
            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();




        }




        //https://www.tektutorialshub.com/entity-framework/ef-eager-loading/


        static void QueryingEagerExample1()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var product = (from p in db.Products
                               .Include("ProductModel")    //ProductModel table to be included in the result 
                               where p.ProductID == 814
                               select p).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

        }

        static void QueryingEagerExample2()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var product = (from p in db.Products
                                .Include(p => p.ProductModel) // Using Lambda Expression instead of a string
                               where p.ProductID == 814
                               select p).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT
            //[Extent1].[ProductID] AS [ProductID],
            //[Extent1].[Name] AS [Name],
            //[Extent1].[ProductNumber] AS [ProductNumber],
            //[Extent1].[MakeFlag] AS [MakeFlag],
            //[Extent1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //[Extent1].[Color] AS [Color],
            //[Extent1].[SafetyStockLevel] AS [SafetyStockLevel],
            //[Extent1].[ReorderPoint] AS [ReorderPoint],
            //[Extent1].[StandardCost] AS [StandardCost],
            //[Extent1].[ListPrice] AS [ListPrice],
            //[Extent1].[Size] AS [Size],
            //[Extent1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //[Extent1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //[Extent1].[Weight] AS [Weight],
            //[Extent1].[DaysToManufacture] AS [DaysToManufacture],
            //[Extent1].[ProductLine] AS [ProductLine],
            //[Extent1].[Class] AS [Class],
            //[Extent1].[Style] AS [Style],
            //[Extent1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //[Extent1].[ProductModelID] AS [ProductModelID],
            //[Extent1].[SellStartDate] AS [SellStartDate],
            //[Extent1].[SellEndDate] AS [SellEndDate],
            //[Extent1].[DiscontinuedDate] AS [DiscontinuedDate],
            //[Extent1].[rowguid] AS [rowguid],
            //[Extent1].[ModifiedDate] AS [ModifiedDate],
            //[Extent2].[ProductModelID] AS [ProductModelID1],
            //[Extent2].[Name] AS [Name1],
            //[Extent2].[CatalogDescription] AS [CatalogDescription],
            //[Extent2].[Instructions] AS [Instructions],
            //[Extent2].[rowguid] AS [rowguid1],
            //[Extent2].[ModifiedDate] AS [ModifiedDate1]
            //FROM  [Production].[Product] AS [Extent1]
            //LEFT OUTER JOIN [Production].[ProductModel] AS [Extent2] ON [Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //WHERE 814 = [Extent1].[ProductID]

        }

        static void QueryingEagerExample3()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var product = (from p in db.Products
                                .Include(p => p.ProductModel)
                                .Include(p => p.ProductSubcategory)
                               where p.ProductID == 931
                               select p).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name, p.ProductSubcategory.Name);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

        }

        static void QueryingEagerExample4()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var person = (from p in db.SalesPersons
                                .Include(p => p.Employee.Person)
                              select p).Take(5).ToList();

                foreach (var p in person)
                {
                    Console.WriteLine("{0}", p.Employee.Person.FirstName);
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

        }

        static void QueryingEagerExample5()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var product = (from p in db.Products
                                .Include(p => p.ProductModel)
                                .Include(p => p.ProductVendors.Select(i => i.Vendor))
                               where p.ProductID == 931
                               select p).ToList();

                foreach (var p in product)
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);

                    foreach (var v in p.ProductVendors)
                    {
                        Console.WriteLine("{0}", v.Vendor.Name);
                    }
                }
            }

            Console.WriteLine("Press Any key to continue .... ");
            Console.ReadLine();

            //SELECT
            //    [Project1].[ProductID] AS [ProductID],
            //    [Project1].[Name] AS [Name],
            //    [Project1].[ProductNumber] AS [ProductNumber],
            //    [Project1].[MakeFlag] AS [MakeFlag],
            //    [Project1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //    [Project1].[Color] AS [Color],
            //    [Project1].[SafetyStockLevel] AS [SafetyStockLevel],
            //    [Project1].[ReorderPoint] AS [ReorderPoint],
            //    [Project1].[StandardCost] AS [StandardCost],
            //    [Project1].[ListPrice] AS [ListPrice],
            //    [Project1].[Size] AS [Size],
            //    [Project1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //    [Project1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //    [Project1].[Weight] AS [Weight],
            //    [Project1].[DaysToManufacture] AS [DaysToManufacture],
            //    [Project1].[ProductLine] AS [ProductLine],
            //    [Project1].[Class] AS [Class],
            //    [Project1].[Style] AS [Style],
            //    [Project1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //    [Project1].[ProductModelID] AS [ProductModelID],
            //    [Project1].[SellStartDate] AS [SellStartDate],
            //    [Project1].[SellEndDate] AS [SellEndDate],
            //    [Project1].[DiscontinuedDate] AS [DiscontinuedDate],
            //    [Project1].[rowguid] AS [rowguid],
            //    [Project1].[ModifiedDate] AS [ModifiedDate],
            //    [Project1].[ProductModelID1] AS [ProductModelID1],
            //    [Project1].[Name1] AS [Name1],
            //    [Project1].[CatalogDescription] AS [CatalogDescription],
            //    [Project1].[Instructions] AS [Instructions],
            //    [Project1].[rowguid1] AS [rowguid1],
            //    [Project1].[ModifiedDate1] AS [ModifiedDate1],
            //    [Project1].[C1] AS [C1],
            //    [Project1].[ProductID1] AS [ProductID1],
            //    [Project1].[BusinessEntityID] AS [BusinessEntityID],
            //    [Project1].[AverageLeadTime] AS [AverageLeadTime],
            //    [Project1].[StandardPrice] AS [StandardPrice],
            //    [Project1].[LastReceiptCost] AS [LastReceiptCost],
            //    [Project1].[LastReceiptDate] AS [LastReceiptDate],
            //    [Project1].[MinOrderQty] AS [MinOrderQty],
            //    [Project1].[MaxOrderQty] AS [MaxOrderQty],
            //    [Project1].[OnOrderQty] AS [OnOrderQty],
            //    [Project1].[UnitMeasureCode] AS [UnitMeasureCode],
            //    [Project1].[ModifiedDate2] AS [ModifiedDate2],
            //    [Project1].[BusinessEntityID1] AS [BusinessEntityID1],
            //    [Project1].[AccountNumber] AS [AccountNumber],
            //    [Project1].[Name2] AS [Name2],
            //    [Project1].[CreditRating] AS [CreditRating],
            //    [Project1].[PreferredVendorStatus] AS [PreferredVendorStatus],
            //    [Project1].[ActiveFlag] AS [ActiveFlag],
            //    [Project1].[PurchasingWebServiceURL] AS [PurchasingWebServiceURL],
            //    [Project1].[ModifiedDate3] AS [ModifiedDate3]
            //    FROM ( SELECT
            //        [Extent1].[ProductID] AS [ProductID],
            //        [Extent1].[Name] AS [Name],
            //        [Extent1].[ProductNumber] AS [ProductNumber],
            //        [Extent1].[MakeFlag] AS [MakeFlag],
            //        [Extent1].[FinishedGoodsFlag] AS [FinishedGoodsFlag],
            //        [Extent1].[Color] AS [Color],
            //        [Extent1].[SafetyStockLevel] AS [SafetyStockLevel],
            //        [Extent1].[ReorderPoint] AS [ReorderPoint],
            //        [Extent1].[StandardCost] AS [StandardCost],
            //        [Extent1].[ListPrice] AS [ListPrice],
            //        [Extent1].[Size] AS [Size],
            //        [Extent1].[SizeUnitMeasureCode] AS [SizeUnitMeasureCode],
            //        [Extent1].[WeightUnitMeasureCode] AS [WeightUnitMeasureCode],
            //        [Extent1].[Weight] AS [Weight],
            //        [Extent1].[DaysToManufacture] AS [DaysToManufacture],
            //        [Extent1].[ProductLine] AS [ProductLine],
            //        [Extent1].[Class] AS [Class],
            //        [Extent1].[Style] AS [Style],
            //        [Extent1].[ProductSubcategoryID] AS [ProductSubcategoryID],
            //        [Extent1].[ProductModelID] AS [ProductModelID],
            //        [Extent1].[SellStartDate] AS [SellStartDate],
            //        [Extent1].[SellEndDate] AS [SellEndDate],
            //        [Extent1].[DiscontinuedDate] AS [DiscontinuedDate],
            //        [Extent1].[rowguid] AS [rowguid],
            //        [Extent1].[ModifiedDate] AS [ModifiedDate],
            //        [Extent2].[ProductModelID] AS [ProductModelID1],
            //        [Extent2].[Name] AS [Name1],
            //        [Extent2].[CatalogDescription] AS [CatalogDescription],
            //        [Extent2].[Instructions] AS [Instructions],
            //        [Extent2].[rowguid] AS [rowguid1],
            //        [Extent2].[ModifiedDate] AS [ModifiedDate1],
            //        [Join2].[ProductID] AS [ProductID1],
            //        [Join2].[BusinessEntityID1] AS [BusinessEntityID],
            //        [Join2].[AverageLeadTime] AS [AverageLeadTime],
            //        [Join2].[StandardPrice] AS [StandardPrice],
            //        [Join2].[LastReceiptCost] AS [LastReceiptCost],
            //        [Join2].[LastReceiptDate] AS [LastReceiptDate],
            //        [Join2].[MinOrderQty] AS [MinOrderQty],
            //        [Join2].[MaxOrderQty] AS [MaxOrderQty],
            //        [Join2].[OnOrderQty] AS [OnOrderQty],
            //        [Join2].[UnitMeasureCode] AS [UnitMeasureCode],
            //        [Join2].[ModifiedDate1] AS [ModifiedDate2],
            //        [Join2].[BusinessEntityID2] AS [BusinessEntityID1],
            //        [Join2].[AccountNumber] AS [AccountNumber],
            //        [Join2].[Name] AS [Name2],
            //        [Join2].[CreditRating] AS [CreditRating],
            //        [Join2].[PreferredVendorStatus] AS [PreferredVendorStatus],
            //        [Join2].[ActiveFlag] AS [ActiveFlag],
            //        [Join2].[PurchasingWebServiceURL] AS [PurchasingWebServiceURL],
            //        [Join2].[ModifiedDate2] AS [ModifiedDate3],
            //        CASE WHEN ([Join2].[ProductID] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
            //        FROM   [Production].[Product] AS [Extent1]
            //        LEFT OUTER JOIN [Production].[ProductModel] AS [Extent2] ON [Extent1].[ProductModelID] = [Extent2].[ProductModelID]
            //        LEFT OUTER JOIN  (SELECT [Extent3].[ProductID] AS [ProductID], [Extent3].[BusinessEntityID] AS [BusinessEntityID1], [Extent3].[AverageLeadTime] AS [AverageLeadTime], [Extent3].[StandardPrice] AS [StandardPrice], [Extent3].[LastReceiptCost] AS [LastReceiptCost], [Extent3].[LastReceiptDate] AS [LastReceiptDate], [Extent3].[MinOrderQty] AS [MinOrderQty], [Extent3].[MaxOrderQty] AS [MaxOrderQty], [Extent3].[OnOrderQty] AS [OnOrderQty], [Extent3].[UnitMeasureCode] AS [UnitMeasureCode], [Extent3].[ModifiedDate] AS [ModifiedDate1], [Extent4].[BusinessEntityID] AS [BusinessEntityID2], [Extent4].[AccountNumber] AS [AccountNumber], [Extent4].[Name] AS [Name], [Extent4].[CreditRating] AS [CreditRating], [Extent4].[PreferredVendorStatus] AS [PreferredVendorStatus], [Extent4].[ActiveFlag] AS [ActiveFlag], [Extent4].[PurchasingWebServiceURL] AS [PurchasingWebServiceURL], [Extent4].[ModifiedDate] AS [ModifiedDate2]
            //            FROM  [Purchasing].[ProductVendor] AS [Extent3]
            //            INNER JOIN [Purchasing].[Vendor] AS [Extent4] ON [Extent3].[BusinessEntityID] = [Extent4].[BusinessEntityID] ) AS [Join2] ON [Extent1].[ProductID] = [Join2].[ProductID]
            //        WHERE 931 = [Extent1].[ProductID]
            //    )  AS [Project1]
            //    ORDER BY [Project1].[ProductID] ASC, [Project1].[ProductModelID1] ASC, [Project1].[C1] ASC


        }


        //https://www.tektutorialshub.com/entity-framework/ef-explicit-loading/

        static void QueryingExpicitExample1()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                //Disable Lazy Loading
                db.Configuration.LazyLoadingEnabled = false;
                //Log Database
                db.Database.Log = Console.Write;

                //List of Products queried here.
                var product = (from p in db.Products
                               orderby p.ProductID descending
                               select p).Take(5).ToList();

                foreach (var p in product)
                {
                    //Product model is retrieved here
                    db.Entry(p).Reference(m => m.ProductModel).Load();
                    Console.WriteLine("{0} {1} Product Model => {2}", p.ProductID, p.Name, (p.ProductModel == null) ? "" : p.ProductModel.Name);

                }

            }
            Console.ReadKey();


        }

        static void QueryingExpicitExample2()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var productModel = (from pm in db.ProductModels
                                    select pm).Take(5).ToList();

                foreach (var pm in productModel)
                {
                    db.Entry(pm).Collection(p => p.Products).Load();
                    foreach (var p in pm.Products)
                    {
                        Console.WriteLine(" {0}", p.Name);
                    }
                    Console.ReadKey();

                }
            }

            Console.ReadKey();


        }

        static void QueryingExpicitExample3()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.dbquery.include?view=entity-framework-6.2.0#System_Data_Entity_Infrastructure_DbQuery_Include_System_String_


            using (AdventureWorks db = new AdventureWorks())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Database.Log = Console.Write;

                var productModel = (from pm in db.ProductModels
                                    select pm).Take(5).ToList();

                foreach (var pm in productModel)
                {
                    db.Entry(pm).Collection(p => p.Products).Query().Where(p => p.ListPrice > 30).Load();
                    foreach (var p in pm.Products)
                    {
                        Console.WriteLine(" {0}", p.Name);
                    }
                    Console.ReadKey();

                }
            }

            Console.ReadKey();


        }

    }
}







