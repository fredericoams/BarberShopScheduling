﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PrismBarbearia.Models;
using System;
using System.Diagnostics;
using Prism.Services;

namespace PrismBarbearia.ViewModels
{
    public class SchedulesWeekPageViewModel : BaseViewModel
    {
        private ObservableCollection<BarberShopAppointment> eventsCollection;
        public ObservableCollection<BarberShopAppointment> EventsCollection
        {
            get { return eventsCollection; }
            set { SetProperty(ref eventsCollection, value); }
        }

        public BarberServices servico;

        //--------------------------------------------------CONSTRUTOR-------------------------------------------------//
        public SchedulesWeekPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Agenda";
            //-------------------------------------------------TESTES--------------------------------------------------//                        
            servico = new BarberServices();
            EventsCollection = new ObservableCollection<BarberShopAppointment>();         
            
            cortarCabelo();
            fazerBarba();
        }

        public void novoEventoPintarCabelo(DateTime dateTime)
        {
            BarberShopAppointment pintarCabelo = new BarberShopAppointment();
            pintarCabelo.From = dateTime;
            pintarCabelo.To = pintarCabelo.From.AddHours(1);
            servico.Name = "pintar cabelo";
            pintarCabelo.EventName = servico.Name;
            pintarCabelo.Color = Color.Pink;
            EventsCollection.Add(pintarCabelo);
        }

        public void cancelarEvento(object evento)
        {            
            EventsCollection.Remove(evento as BarberShopAppointment);
        }

        public void fazerBarba()
        {
            BarberShopAppointment fazerBarba = new BarberShopAppointment();
            fazerBarba.From = new DateTime(2017, 06, 29, 10, 0, 0);
            fazerBarba.To = fazerBarba.From.AddHours(0.5);
            servico.Name = "fazer barba";
            fazerBarba.EventName = servico.Name;
            fazerBarba.Color = Color.Blue;
            EventsCollection.Add(fazerBarba);
        }

        public void cortarCabelo()
        {
            BarberShopAppointment cortarCabelo = new BarberShopAppointment();
            cortarCabelo.From = new DateTime(2017, 06, 28, 10, 0, 0);
            cortarCabelo.To = cortarCabelo.From.AddHours(0.5);//30 minutos de duração
            servico.Name = "cortar cabelo";
            cortarCabelo.EventName = servico.Name;
            cortarCabelo.Color = Color.Green;
            EventsCollection.Add(cortarCabelo);
        }

    }
}

/* private ScheduleAppointmentCollection scheduleAppointmentCollection; GAMBIARRA PRA TER HORARIO DE ALMOCO NO ANDROID E COME PERFORMANCE '-'
       public ScheduleAppointmentCollection ScheduleAppointmentCollection
       {
           get { return scheduleAppointmentCollection; }
           set { SetProperty(ref scheduleAppointmentCollection, value); }
       }

           scheduleAppointmentCollection = new ScheduleAppointmentCollection();
           var scheduleAppointment = new ScheduleAppointment()
           {
               StartTime = new DateTime(2017, 06, 26, 11, 0, 0),
               EndTime = new DateTime(2017, 06, 26, 13, 0, 0),
               Subject = "Almoço",
               IsRecursive = true
           };
           //Adding schedule appointment in schedule appointment collection
           scheduleAppointmentCollection.Add(scheduleAppointment);

           //Adding schedule appointment collection to DataSource of SfSchedule

           // Creating recurrence rule
           RecurrenceProperties recurrenceProperties = new RecurrenceProperties();
           recurrenceProperties.RecurrenceType = RecurrenceType.Daily;
           recurrenceProperties.IsRangeRecurrenceCount = true;
           recurrenceProperties.DailyNDays = 1;
           recurrenceProperties.IsDailyEveryNDays = true;
           recurrenceProperties.RangeRecurrenceCount = 365*3;
           recurrenceProperties.RecurrenceRule = DependencyService.Get<IRecurrenceBuilder>().RRuleGenerator(recurrenceProperties, scheduleAppointment.StartTime, scheduleAppointment.EndTime);

           // Setting recurrence rule to schedule appointment
           scheduleAppointment.RecurrenceRule = recurrenceProperties.RecurrenceRule;*/
