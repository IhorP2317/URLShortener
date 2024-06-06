import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UntilDestroy, untilDestroyed} from "@ngneat/until-destroy";
import {ShortenUrl} from "../../core/interfaces/shorten-url";
import {UrlShortenerEndpointService} from "../../core/services/url-shortener.endpoint.service";
import {UrlViewModel} from "../../core/interfaces/url-view-model";
import {tap} from "rxjs";
import {AlertService} from "../../shared/services/alert.service";
@UntilDestroy()
@Component({
  selector: 'app-url-table',
  templateUrl: './url-table.component.html',
  styleUrl: './url-table.component.scss'
})
export class UrlTableComponent implements OnInit{
  urlForm!: FormGroup;
  dataSource!: ShortenUrl[];
  constructor(private urlShortenerService:UrlShortenerEndpointService, private fb:FormBuilder, private alertService: AlertService){
  }
  ngOnInit() {
   this.initializeUrlForm()
    this.loadUrls();

  }
initializeUrlForm() {
  this.urlForm = this.fb.group({
    inputUrl: ['', [
      Validators.required,
      Validators.pattern('^(?:https?://)?(?:www\\.)?[\\w\\-\\.]+\\.\\w{2,}(?:\\.\\w{2,})?(?:[\\w\\-._/?=#&%]*?)$')
    ]]
  });
}
  loadUrls() {
    this.urlShortenerService.getAllUrls().pipe(untilDestroyed(this)).subscribe(urls => {
      this.dataSource = urls;
    });
  }
  onSubmit() {
    if (this.urlForm.valid && this.dataSource.find(x => x.fullUrl === this.urlForm.get('inputUrl')?.value) == null) {
      const inputUrl = this.urlForm.get('inputUrl')?.value;
      const urlViewModel: UrlViewModel = { url: inputUrl, createdBy: '' }; // Add actual createdBy value here
      this.urlShortenerService.addUrl(urlViewModel).pipe(tap(() =>  this.loadUrls()),untilDestroyed(this)).subscribe();
    }
  }
  onInfo(url: ShortenUrl) {
    this.urlShortenerService.redirectToUrlInfo(url);
  }
  onDelete(url: ShortenUrl) {
    this.urlShortenerService.deleteUrl(url).pipe(tap(() => this.loadUrls()),untilDestroyed(this)).subscribe(() => {
    });
  }
}
