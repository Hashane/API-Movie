using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace movieOutlet.Controllers
{
    public class movieController : ApiController
    {

        [Route("api/Movies/")]
        [System.Web.Http.AcceptVerbsAttribute("GET")]
        [System.Web.Http.HttpGet]
        public string GetAllProducts()
        {

                List<movy> pro = new List<movy>();
                using (movieoutletEntities contex = new movieoutletEntities())
                {
                    var productList = from m in contex.movies select m;
                    movy pros = new movy();
                    pro = productList.ToList();
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    return json.Serialize(pro);


                }


        }



        [Route("api/Movies/{id:int?}")]
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
           
                List<movy> pro = new List<movy>();
                using (movieoutletEntities contex = new movieoutletEntities())
                {
                    var movieList = from m in contex.movies select m;
                    movy pros = new movy();
                    pro = movieList.ToList();
                    JavaScriptSerializer json = new JavaScriptSerializer();


                    var product = pro.FirstOrDefault((p) => p.Id == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                    return Ok(json.Serialize(product));
                }
            }



        [Route("api/Movies/{category}")]
        [HttpGet]
        public IHttpActionResult GetCat(string category)
        {

                List<movy> pro = new List<movy>();
                using (movieoutletEntities contex = new movieoutletEntities())
                {
                    var productList = from m in contex.movies where m.Category == category select m;
                    movy pros = new movy();
                    pro = productList.ToList();
                    JavaScriptSerializer json = new JavaScriptSerializer();



                    if (pro == null)
                    {
                        return NotFound();
                    }
                    return Ok(json.Serialize(pro));
                }
            }



        [Route("api/Movies/")]
        [HttpPost]
        public string Post(movy pro)
        {
                JavaScriptSerializer json = new JavaScriptSerializer();
                movy itm = new movy();
                itm.Id = pro.Id;
                itm.Name = pro.Name;
                itm.Category = pro.Category;
                itm.Price = pro.Price;
                itm.Description = pro.Description;

                using (movieoutletEntities contex = new movieoutletEntities())
                {
                    contex.movies.Add(itm);
                    contex.SaveChanges();
                    return json.Serialize("Successful");
                }
        }



        [Route("api/Movies/{id:int?}")]
        [HttpPut]
        public string Update(int id, movy pro)
        {
           
            movy itm = new movy();
            using (movieoutletEntities contex = new movieoutletEntities())
                {
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    var productList = from m in contex.movies where m.Id == id select m;
                    itm = productList.First();
                    contex.movies.Remove(itm);
                    contex.SaveChanges();

                    itm.Id = pro.Id;
                    itm.Name = pro.Name;
                    itm.Category = pro.Category;
                    itm.Price = pro.Price;
                    itm.Description = pro.Description;
                  
                    contex.movies.Add(itm);
                    contex.SaveChanges();
                    return json.Serialize("Successful");
                }
            }


        [Route("api/Movies/{id:int?}")]
        [HttpDelete]
        public string Delete(int id)
        {
           
                movy itm = new movy();
                using (movieoutletEntities contex = new movieoutletEntities())
                {
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    var productList = from m in contex.movies where m.Id == id select m;
                    itm = productList.First();
                    contex.movies.Remove(itm);
                    contex.SaveChanges();
                    return json.Serialize("Successful");
                }

            }
          
    }

    }

    
