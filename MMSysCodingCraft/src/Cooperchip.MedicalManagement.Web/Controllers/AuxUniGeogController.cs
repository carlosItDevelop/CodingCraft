using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuxUniGeogController : Controller
    {
        MedicalManagementDbContext db = new MedicalManagementDbContext();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GravaJson()
        {

            IEnumerable<UnidadeGeografica> unig = new List<UnidadeGeografica>();

            //unig = (from u in db.UnidadeGeografica select u)
            //            .Where(x => x.UnidadeGeograficaId > 1000000 && x.UnidadeGeograficaId < 1200001).ToList();

            unig = (from u in db.UnidadeGeografica select u)
                        .Where(x => x.UnidadeGeograficaId > 0 && x.UnidadeGeograficaId < 201).ToList();


            string json = JsonConvert.SerializeObject(unig);

            //System.IO.File.WriteAllText("~/json/unidadegeografica.json", json);

            var caminho = @"H:\Repositories\DevEvoluMed\evolumedsys\Cooperchip.MedicalManagement.Web\json\unidadegeograficateste.json";
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                    System.IO.File.AppendAllText(caminho, json);
                    return View("Index");
                }
                else
                {
                    ViewBag.Erro = "Não há registros para serem gravados!";
                    return RedirectToAction("Erro", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message + " - Código: " + ex.HResult;
                return RedirectToAction("Erro", "Home");
            }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult LerJson()
        {
            try
            {
                IRestResponse response = LerArquivoJson(@"H:\Repositories\DevEvoluMed\evolumedsys\Cooperchip.MedicalManagement.Web\json\unidadegeograficateste.json");

                var unigeog = JsonConvert.DeserializeObject<UnidadeGeografica>(response.Content);

                //var k = 0;
                //foreach (var item in unigeog)
                //{
                //    item[k].
                //        k++;
                //}
                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message + " - Código: " + ex.HResult;
                return RedirectToAction("Erro", "Home");
            }

        }


        static IRestResponse LerArquivoJson(string arquivo)
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            using (StreamReader r = new StreamReader(arquivo))
            {
                string json = r.ReadToEnd();
                dynamic array = serializer.DeserializeObject(json);

                return serializer.Serialize(array);

                //Console.WriteLine("");
                //Console.WriteLine(serializer.Serialize(array));
                //Console.WriteLine("");
                //Console.ReadKey();
            }
        }



    }
}