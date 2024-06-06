import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ShortenUrl} from "../interfaces/shorten-url";
import {UrlViewModel} from "../interfaces/url-view-model";

@Injectable({
  providedIn: 'root'
})
export class UrlShortenerEndpointService {

  constructor(private  http: HttpClient, @Inject('apiUrl') private baseUrl:string) { }
  getAllUrls() {
   return this.http.get<ShortenUrl[]>(`${this.baseUrl}/Url/GetAll`);
  }
  addUrl(url:UrlViewModel) {
   return this.http.post<ShortenUrl>(`${this.baseUrl}/Url/Add`, url);
  }
  deleteUrl(url: ShortenUrl) {
   return this.http.delete(`${this.baseUrl}/Url/Remove?id=${url.id}`);
  }
  redirectToUrlInfo(url: ShortenUrl) {
    window.open(`${this.baseUrl}/Url/Info?id=${url.id}`)
  }
}
