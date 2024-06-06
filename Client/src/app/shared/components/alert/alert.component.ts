import {Component, OnInit} from '@angular/core';
import {UntilDestroy, untilDestroyed} from "@ngneat/until-destroy";
import {AlertMessage} from "../../../core/interfaces/alert-message";
import {AlertService} from "../../services/alert.service";
@UntilDestroy()
@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrl: './alert.component.scss'
})
export class AlertComponent implements OnInit {
  message!: AlertMessage | null;

  constructor(private alertService: AlertService) { }

  ngOnInit() {
    this.alertService.alert$.pipe(untilDestroyed(this)).subscribe(message => {
      switch (message?.type) {
        case 'success':
          message.cssClass = 'alert alert-success';
          break;
        case 'error':
          message.cssClass = 'alert alert-danger';
          break;
        case 'info':
          message.cssClass = 'alert alert-info';
          break;
        case 'warn':
          message.cssClass = 'alert alert-warning';
          break;
      }

      this.message = message;
    });
  }
}
