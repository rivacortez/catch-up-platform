var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Configure Kebab Case Route Naming Convention
*/

//don´t delete
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Add Database Connection
 */


/* Configure Database Context and Logging Levels
*/

/* Configure Lowercase URLs
*/


/* Configure Kebab Case Route Naming Convention
*/


// Configure Dependency Injection
/* Shared Bounded Context Injection Configuration
*/




/*put Bounded Context Injection Configuration
*/


//don´t delete
var app = builder.Build();




/*put ->  Verify Database Objects are created
*/




//no eliminar
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

