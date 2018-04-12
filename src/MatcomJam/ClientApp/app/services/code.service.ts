import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Code } from "../models/code.model";

@Injectable()
export class CodeService {

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

    upload(userId, problemId, languageId, file) {
        var formData = new FormData();
        formData.append('file', file);
        var query = `?userId=${userId}&problemId=${problemId}&languageId=${languageId}`;
        return this.http.post(`/api/Code/Save` + query, formData);
    }
}
