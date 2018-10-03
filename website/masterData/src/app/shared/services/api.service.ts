import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';

import { OrganizationListModel } from '../models/organization/organization-list.model';
import { OrganizationEditModel } from '../models/organization/organization-edit.model';

import { PositionListModel } from '../models/position/position-list.model';
import { PositionEditModel } from '../models/position/position-edit.model';

@Injectable()
export class ApiService {

    constructor(private http: HttpClient) { }

    // Organizations

    public getOrganizations(): any {
        return this.http.get<OrganizationListModel[]>(`${environment.apiUrl}/api/Organizations`);
    }

    public getOrganizationDropdownValues(): any {
        return this.getOrganizations()
            .pipe(
                map(
                    (items: Array<{ id: string, name: string }>) => {
                        const result = new Array<{ key: string, value: string }>();
                        items.forEach((item: any) => result.push({ key: item.id, value: item.name }));
                        return result;
                    }
                )
            );
    }    

    public addOrganization(body): any {
        return this.http.post(`${environment.apiUrl}/api/Organizations`, body);
    }

    public editOrganization(id: string, body: OrganizationEditModel): any {
        return this.http.put(`${environment.apiUrl}/api/Organizations/${id}`, body);
    }

    public deleteOrganization(item: OrganizationListModel): any {
        return this.http.delete(`${environment.apiUrl}/api/Organizations/${item.id}`);
    }

    // POSITION

    public getPositions(): any {
        return this.http.get<PositionListModel[]>(`${environment.apiUrl}/api/Positions`);
    }

    public getPositionDropDownValues(): any {
        return this.getPositions()
            .pipe(
                map(
                    (items: Array<{ id: string, name: string }>) => {
                        const result = new Array<{ key: string, value: string }>();
                        items.forEach((item: any) => result.push({ key: item.id, value: item.name }));
                        return result;
                    }
                )
            );
    }

    public addPosition(body): any {
        return this.http.post(`${environment.apiUrl}/api/Positions`, body);
    }

    public editPosition(id: string, body: PositionEditModel) {
        return this.http.put(`${environment.apiUrl}/api/Positions/${id}`, body);
    }

    public deletePosition(item: PositionListModel) : any {
        return this.http.delete(`${environment.apiUrl}/api/Positions/${item.id}`);
    }
}
