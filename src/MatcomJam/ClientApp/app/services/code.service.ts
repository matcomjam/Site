import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Code } from "../models/code.model";

@Injectable()
export class CodeService {

    private _getUrl = '/api/Code/Index';
    public _saveUrl: string = 'api/Code/Save';
    public _updateUrl: string = 'api/Code/Update/';
    public _deleteByIdUrl: string = 'api/Code/Delete/';

    constructor(private http: HttpClient) { }

    //upload(code: Code) {
    //    return this.http.post(`/api/problems/${code.ProblemId}/code`, code);
    //}

    //upload2(userId, languageId, problemId, file:File) {
    //    var formData = new FormData();
    //    formData.append('file', file);
    //    var t = file.msDetachStream()
    //    console.log()
    //}

    upload<T>(userId, problemId, languageId, file) {
        var formData = new FormData();
        formData.append('file', file);
        var query = `?userId=${userId}&problemId=${problemId}&languageId=${languageId}`;
        return this.http.post(this._getUrl + query, formData);
    }

    getCodes<T>() {
        return this.http.get(this._getUrl + "All");
    }
}
