import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { UpdateUserRightDTO } from 'src/app/models/DTO/User/updateUserRightDTO';
import { DeleteCollaboratorRightDTO } from 'src/app/models/DTO/Common/deleteCollaboratorRightDTO';
import { UserAccess } from 'src/app/models/Enums/userAccess';

@Injectable({
    providedIn: 'root'
})
export class RightsService {

    private address = 'rights';

    constructor(private httpClient: HttpClientWrapperService) { }

    public setUsersRigths(update: UpdateUserRightDTO): Observable<HttpResponse<[]>> {
        return this.httpClient.putRequest(this.address, update);
    }

    public getUserRightById(userId: number, projectId: number): Observable<HttpResponse<UserAccess>>
    {
        return this.httpClient.getRequest(this.address+'/'+userId+'/'+projectId);
    }

    public deleteCollaborator(deleteCollaborator: DeleteCollaboratorRightDTO)
    {
        return this.httpClient.deleteRequest(this.address+'/'+deleteCollaborator.id+'/'+deleteCollaborator.projectId);
    }
}
