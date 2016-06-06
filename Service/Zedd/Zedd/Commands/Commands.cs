using NHibernate.Criterion;
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

    public void Delete<T>(int id)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq("Id", id)).UniqueResult();

          if (entity != null)
          {
            session.Delete(entity);
            transaction.Commit();
          }
        }
      }
    }

    public void Edit(UserEdit userInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Users>().Where(users => users.Id == userInfo.Id).SingleOrDefault();

          entity.IsAdmin = userInfo.IsAdmin;
          entity.Name = userInfo.Name;
          entity.Surname = userInfo.Surname;
          entity.Unit = new Unit { Id = userInfo.Unit.Id };

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void Edit(UserInfo userInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Users>().Where(users => users.Id == userInfo.Id).SingleOrDefault();

          entity.IsAdmin = userInfo.IsAdmin;
          entity.Name = userInfo.Name;
          entity.Surname = userInfo.Surname;
          entity.Unit = new Unit { Id = userInfo.Unit.Id };
          entity.Password = userInfo.Password;
          entity.Login = userInfo.Login;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void ChangePassword(int id, string newPassword, string oldPassword)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Users>().Where(users => users.Id == id).SingleOrDefault();

          if (oldPassword == entity.Password)
          {
            entity.Password = newPassword;

            session.Update(entity);
            transaction.Commit();
          }
          else
          {
            throw new Exception("wrong password");
          }
        }
      }
    }

    public void Edit(LibraryInfo libraryInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Libraries>().Where(users => users.Id == libraryInfo.Id).SingleOrDefault();

          entity.AdditionalInfo = libraryInfo.AdditionalInfo;
          entity.Address = libraryInfo.Address;
          entity.Name = libraryInfo.Name;
          entity.OpeningHours = libraryInfo.OpeningHours;
          entity.UserId = libraryInfo.UserId;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void Edit(EventInfo eventInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Events>().Where(users => users.Id == eventInfo.Id).SingleOrDefault();

          entity.Content = eventInfo.Content;
          entity.Date = DateTime.Parse(eventInfo.Date);
          entity.Department = new Departments { Id = eventInfo.Department.Id };
          entity.NotificationDate = DateTime.Parse(eventInfo.NotificationDate);
          entity.Title = eventInfo.Title;
          entity.UserId = eventInfo.UserId;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void Edit(Department departmentInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Departments>().Where(users => users.Id == departmentInfo.Id).SingleOrDefault();

          entity.Name = departmentInfo.Name;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void Edit(DeansOfficeInfo deansOfficeInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<DeansOffices>().Where(users => users.Id == deansOfficeInfo.Id).SingleOrDefault();

          entity.AdditionalInfo = deansOfficeInfo.AdditionalInfo;
          entity.Address = deansOfficeInfo.Address;
          entity.Department = new Departments { Id = deansOfficeInfo.Department.Id };
          entity.OpeningHours = deansOfficeInfo.OpeningHours;
          entity.UserId = deansOfficeInfo.UserId;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void Edit(UnitInfo unitInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Unit>().Where(users => users.Id == unitInfo.Id).SingleOrDefault();

          entity.Description = unitInfo.Description;
          entity.Name = unitInfo.Name;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }

    public void Edit(MessageInfo messageInfo)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var entity = session.QueryOver<Messages>().Where(users => users.Id == messageInfo.Id).SingleOrDefault();

          entity.Content = messageInfo.Content;
          entity.Department = messageInfo.Department;
          entity.Important = messageInfo.Important;
          entity.Title = messageInfo.Title;
          entity.UserId = messageInfo.UserId;

          session.Update(entity);
          transaction.Commit();
        }
      }
    }
  }
}