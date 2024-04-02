Employee demo app 

  Technology Implementation 
    
    - Asp.net Core 8 (Backend API)
      - Static Login (username: admin, password: @admin)
      - JWT Token implementation 
      - Clean Architecture - Code structure (Hexagonal Pattern)
      - API documentation - swagger 
    - Angular (Front-End)
      - Angular Version 14
      - Bootstrap 
  
  
  Up & Running for development
    - Backend API 
    - Front-End 
    
    For demo purpose can  used with sqlite connection 
    var cs = builder.Configuration.GetConnectionString("MSSqlServer");
    var sqlite = builder.Configuration.GetConnectionString("Sqlite");

    //builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(cs));
    builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlite(sqlite));
    
    
  Features:
    - Login 
    - Dashboard 
    - Page 
      - Employee list
      - Export Employee Export PDF
      - Employee detail
      - Employee create new
      - Employee update