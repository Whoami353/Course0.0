using Cursos0._0.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cursos0._0.Startup))]
namespace Cursos0._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			CrearRolesConUsuario();
		}
		private void CrearRolesConUsuario()
		{
			//Acceder al modelo de seguridad
			ApplicationDbContext context = new ApplicationDbContext();

			//Manejadores de roles y usuarios
			var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

				//Verificamos la existencia del rol
			if (!ManejadorRol.RoleExists("Admin"))
			{
					//sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
								var rol = new IdentityRole();
					rol.Name = "Admin";
								ManejadorRol.Create(rol);
								//creamos un primer usuario para ese rol
								var user = new ApplicationUser();
					user.UserName = "Admin@gmail.com";
								user.Email = "Admin@gmail.com";
								string pwd = "12345678";
					var chkUser = ManejadorUsuario.Create(user, pwd);
								//si se creo con exito
								if (chkUser.Succeeded)
								{
									ManejadorUsuario.AddToRole(user.Id, "Admin");
								}
			}

			if (!ManejadorRol.RoleExists("Instructor"))
			{
				//sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
				var rol = new IdentityRole();
				rol.Name = "Instructor";
				ManejadorRol.Create(rol);
				//creamos un primer usuario para ese rol
				var user = new ApplicationUser();
				user.UserName = "Inst@gmail.com";
				user.Email = "Inst@gmail.com";
				string PWD = "12345678";
				var chkUser = ManejadorUsuario.Create(user, PWD);
				//si se creo con exito
				if (chkUser.Succeeded)
				{
					ManejadorUsuario.AddToRole(user.Id, "Instructor");
				}
			}

			if (!ManejadorRol.RoleExists("Estudiante"))
			{
				//sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
				var rol = new IdentityRole();
				rol.Name = "Estudiante";
				ManejadorRol.Create(rol);
				//creamos un primer usuario para ese rol
				var user = new ApplicationUser();
				user.UserName = "Estu@gmail.com";
				user.Email = "Estu@gmail.com";
				string PWD = "12345678";
				var chkUser = ManejadorUsuario.Create(user, PWD);
				//si se creo con exito
				if (chkUser.Succeeded)
				{
					ManejadorUsuario.AddToRole(user.Id, "Estudiante");
				}
			}

		}
		
	}
}
