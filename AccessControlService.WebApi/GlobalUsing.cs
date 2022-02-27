global using AccessControlService.Application;
global using AccessControlService.Application.Interfaces;
global using AccessControlService.Application.Common.Mappings;
global using AccessControlService.Application.Common.Exceptions;
global using AccessControlService.Application.Users.Commands.CreateUser;
global using AccessControlService.Application.Users.Commands.UpdateUser;
global using AccessControlService.Application.Users.Commands.DeleteUser;
global using AccessControlService.Application.Users.Queries.GetUserById;
global using AccessControlService.Application.Users.Queries.GetUsers;

global using AccessControlService.Persistence;

global using AccessControlService.WebApi.Controllers;
global using AccessControlService.WebApi.CustomAttributes;
global using AccessControlService.WebApi.ModelsDto;

global using Microsoft.AspNetCore.Mvc;

global using MediatR;

global using AutoMapper;

global using System.Reflection;
global using System.ComponentModel.DataAnnotations;
global using System.Net;
global using System.Text.Json;

