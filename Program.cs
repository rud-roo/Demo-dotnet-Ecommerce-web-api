using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", ()=> {
    return "Api is working fine";
});

app.MapGet("/hello", ()=> {
    var response = new {message="this is a json object", success=true};
    return Results.Ok(response);
});

app.MapGet("/hello1", ()=> {
    return Results.Content("<h1>Hello World</h1>", "text/html");
});

app.MapPost("/hello", ()=> {
    return Results.Created();
});

app.MapPut("/hello", ()=> {
    return Results.NoContent();
});

app.MapDelete("/hello", ()=> {
    return Results.NoContent();
});

var products = new List<Product>(){
    new Product("samsung s24", 900),
    new Product("iphone 16", 900),
};

app.MapGet("/products", () => {
    return Results.Ok(products);
});

app.Run();

public record Product(string Name, decimal Price);