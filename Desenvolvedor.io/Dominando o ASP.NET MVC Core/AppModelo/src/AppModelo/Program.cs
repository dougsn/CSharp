

// Tudo inicia a partir do builder

using AppModelo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o MVC ao container

builder.Services.AddControllersWithViews();


// Injetando dependencia

builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

// Configurando o DbContext

builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDbContext")));

// Realizando o buid das configurações que resultará na App

var app = builder.Build();

// Ativando a pagina de erros caso seja ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Utilizando os arquivos estaticos (bootstrap / Javascrip e etc.)

app.UseStaticFiles();

app.UseHttpsRedirection();

// Adicionando suporte a rota
app.UseRouting();

// Rota padrão
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Rota de área genérica (não necessário no caso da demo)
//app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Rota de áreas especializadas

app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

// Colocando a App para rodar

app.Run();
 