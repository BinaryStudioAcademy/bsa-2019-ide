import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { EditorSettingDTO } from 'src/app/models/DTO/Common/editorSettingDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EditorSettingsService {

    private address: string = 'editorsettings';

  constructor(
      private http: HttpClientWrapperService
  ) { }

  public UpdateEditorSettings(updateDTO: EditorSettingDTO): Observable<HttpResponse<EditorSettingDTO>>{
      return this.http.putRequest(this.address, updateDTO);
  }
}
