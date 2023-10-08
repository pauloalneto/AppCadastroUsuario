import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationsService } from 'angular2-notifications';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiURL = '';

  constructor(private http: HttpClient, private route: Router, private notificationService: NotificationsService) {
    this.apiURL = 'https://localhost:7211/api/';
  }


  public GetWithFilters(resource: string, filters?: any): Observable<any> {
    return this.http.get(this.apiURL + resource, this.RequestOptions(filters))
      .pipe(map(res => {
        return res
      }),
        catchError((error) => {
          if (error.status == 401)
            this.route.navigateByUrl('/unauthorized')

          return error
        }));
  }

  public GetById(resource: string, id: string): Observable<any> {
    return this.http.get(this.apiURL + resource + `/${id}`, this.RequestOptions(null))
      .pipe(map(res => {
        return res
      }),
        catchError((error) => {
          if (error.status == 401)
            this.route.navigateByUrl('/unauthorized')

          return error
        }));
  }

  public Post(resource: string, model: any): Observable<any> {

    var body = JSON.stringify(model, (key, value) => {
      if (value !== null) return value
    })

    return this.http.post(this.apiURL + resource, body, this.RequestOptions(null));
  }

  public Put(resource: string, model: any): Observable<any> {

    var body = JSON.stringify(model, (key, value) => {
      if (value !== null) return value
    })

    return this.http.put(this.apiURL + resource, body, this.RequestOptions(null));
  }

  public Delete(resource: string, id: string): Observable<any> {
    return this.http.delete(this.apiURL + resource + `/${id}`, this.RequestOptions(null));
  }

  private RequestOptions(filters?: any): any {
    let options = {
      headers: this.MakeHeaders(),
      params: this.MakeParams(filters)
    }

    return options;
  }

  private MakeHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json')
      .set('Authorization', 'bearer ' + window.localStorage.getItem('AUTH_TOKEN')?.toString());

    return headers;
  }

  private MakeParams(filters?: any): any {
    let params = new HttpParams()

    if (filters != null) {
      for (const key in filters) {
        if (filters.hasOwnProperty(key)) {
          if(filters[key] != null)
            params = params.set(key, filters[key])
        }
      }
    }

    return params;
  }

  public notificacaoSucesso(titulo: string, mensagem: string) {
    this.notificationService.success(titulo, mensagem, {
      timeOut: 3000,
      showProgressBar: true,
      pauseOnHover: true,
      clickToClose: false,
      clickIconToClose: false
    })
  }

  public notificacaoErro(titulo: string, mensagem: string) {
    this.notificationService.error(titulo, mensagem, {
      timeOut: 3000,
      showProgressBar: true,
      pauseOnHover: true,
      clickToClose: false,
      clickIconToClose: false
    })
  }
}
