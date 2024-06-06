import { Injectable } from '@angular/core';
import {Subject} from "rxjs";
import {AlertMessage} from "../../core/interfaces/alert-message";

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  private alertSubject = new Subject<AlertMessage | null>();
  public alert$ = this.alertSubject.asObservable();
  private keepAfterRouteChange = false;

  constructor() { }


  success(message: string, keepAfterRouteChange = false) {
    this.alert('success', message, keepAfterRouteChange);
  }

  error(message: string, keepAfterRouteChange = false) {
    this.alert('error', message, keepAfterRouteChange);
  }

  info(message: string, keepAfterRouteChange = false) {
    this.alert('info', message, keepAfterRouteChange);
  }

  warn(message: string, keepAfterRouteChange = false) {
    this.alert('warn', message, keepAfterRouteChange);
  }

  alert(type: string, message: string, keepAfterRouteChange = false) {
    this.keepAfterRouteChange = keepAfterRouteChange;
    this.alertSubject.next({type, message });
  }

  clear() {
    this.alertSubject.next(null);
  }
}
