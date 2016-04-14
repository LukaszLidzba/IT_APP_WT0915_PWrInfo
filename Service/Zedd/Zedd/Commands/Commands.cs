using System;
using System.Linq;
using System.Threading;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;
using Zedd.Queries;

namespace Zedd.Commands
{
  public class Commands : ICommands
  {
    private readonly ILoginQueryDao _loginQueryDao;
    private readonly IUserQuery _userQuery;

    public Commands(IUserQuery userQuery = null, ILoginQueryDao loginQueryDao = null)
    {
      _loginQueryDao = loginQueryDao ?? new LoginQueryDao();
      _userQuery = userQuery ?? new UserQueryDao();
    }

    public void AddDeansOffice(AddDeansOfficeRequest request)
    {
      var userId = _loginQueryDao.GetUser(request.Ticket).Id;

      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = new DeansOffices
          {
            AdditionalInfo = request.AdditionalInfo,
            Address = request.Address,
            OpeningHours = request.OpeningHours,
            UserId = userId,
            Department = new Departments
            {
              Id = request.DepartmentId
            }
          };

          session.Save(entity);
          transaction.Commit();
        }
      }
    }

    public void AddLibrary(AddLibraryRequest request)
    {
      var userId = _loginQueryDao.GetUser(request.Ticket).Id;

      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = new Libraries
          {
            UserId = userId,
            AdditionalInfo = request.AdditionalInfo,
            Address = request.Address,
            Name = request.Name,
            OpeningHours = request.OpeningHours
          };

          session.Save(entity);
          transaction.Commit();
        }
      }
    }

    public void AddMessage(AddMessageRequest request)
    {
      var userId = _loginQueryDao.GetUser(request.Ticket).Id;

      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = new Messages
          {
            Content = request.Content,
            Title = request.Title,
            UserId = userId,
            Important = request.Important,
            Department = new Departments
            {
              Id = request.DepartmentId
            }
          };

          session.Save(entity);
          transaction.Commit();
        }
      }
    }

    public void AddEvent(AddEventRequest request)
    {
      var userId = _loginQueryDao.GetUser(request.Ticket).Id;

      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = new Events
          {
            Content = request.Content,
            Date = request.Date,
            NotificationDate = request.NotificationDate,
            Title = request.Title,
            UserId = userId,
            Department = new Departments
            {
              Id = request.DepartmentId
            }
          };

          session.Save(entity);
          transaction.Commit();
        }
      }
    }

    public void AddUnit(AddUnitRequest request)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = new Unit
          {
            Description = request.Description,
            Name = request.Name
          };

          session.Save(entity);
          transaction.Commit();
        }
      }
    }

    public void AddUser(AddUserRequest request)
    {
      var isAdmin = _loginQueryDao.GetUser(request.Ticket).IsAdmin;

      if (!isAdmin)
      {
        throw new Exception("User is not admin therefore cannot add users");
      }

      var taken = _userQuery.GetUsers().Count(x => x.Login == request.Login.Trim());

      if (taken > 0)
      {
        throw new Exception("Login already in use");
      }

      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = new Users
          {
            IsAdmin = request.IsAdmin,
            Name = request.Name,
            Login = request.Login,
            Password = request.Password,
            Surname = request.Surname,
            Unit = new Unit
            {
              Id = request.UnitId
            }
          };

          session.Save(entity);
          transaction.Commit();
        }
      }
    }
  }
}