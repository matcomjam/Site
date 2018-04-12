import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Language } from '../models/language.model'

@Injectable()
export class LanguageService {
    private _getUrl = '/api/Language/Index';
    public _saveUrl: string = 'api/Language/Save';
    public _updateUrl: string = 'api/Language/Update/';
    public _deleteByIdUrl: string = 'api/Language/Delete/';

    constructor(private http: HttpClient) { }

    getLanguages<T>() {
        return this.http.get(this._getUrl);
    }
}
