using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorCondominios.ViewModels;
using GerenciadorCondominiosBLL.Models;
using GerenciadorCondominiosDAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorCondominios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IWebHostEnvironment webHostingEnvironment)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _webHostingEnvironment = webHostingEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //Iformfile name must be the same as the input id on the cshtml related form
        public async Task<IActionResult>  Registro(RegistroViewModel model, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if(Foto != null)
                {
                    string diretorioPasta = Path.Combine(_webHostingEnvironment.WebRootPath, "Images");
                    string nomeFoto = Guid.NewGuid().ToString() + Foto.FileName;

                    using (FileStream fileStream = new FileStream(Path.Combine(diretorioPasta, nomeFoto), FileMode.Create))
                    {
                        await Foto.CopyToAsync(fileStream);
                        model.Foto = "~/Images" + nomeFoto;
                    }

                }

                Usuario usuario = new Usuario();
                IdentityResult usuarioCriado;

                if (_usuarioRepositorio.VerificarSeExisteRegistro() == 0)
                {
                    usuario.UserName = model.Nome;
                    usuario.CPF = model.CPF;
                    usuario.Email = model.Email;
                    usuario.PhoneNumber = model.Telefone;
                    usuario.Foto = model.Foto;
                    usuario.PrimeiroAcesso = false;
                    usuario.Status = StatusConta.Aprovado;

                    usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                    if (usuarioCriado.Succeeded)
                    {
                        await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Administrador");
                        await _usuarioRepositorio.LogarUsuario(usuario, false);
                        return RedirectToAction("Index", "Usuarios");
                    }
                }


                usuario.UserName = model.Nome;
                usuario.CPF = model.CPF;
                usuario.Email = model.Email;
                usuario.PhoneNumber = model.Telefone;
                usuario.Foto = model.Foto;
                usuario.PrimeiroAcesso = true;
                usuario.Status = StatusConta.Analisando;

                usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    return View("Analise", usuario.UserName);
                }
                else
                {
                    foreach(IdentityError error in usuarioCriado.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }


        public IActionResult Analise(string nome)
        {

            return View(nome);
        }
    }
}
