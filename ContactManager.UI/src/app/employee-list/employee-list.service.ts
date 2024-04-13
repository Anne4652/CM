import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private baseUrl = 'https://localhost:7114/api/Employee';

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl);
  }

  uploadCsv(file: File): Observable<any> {
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post<any>(this.baseUrl, formData);
  }

  deleteEmployee(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl, { params: { id: id } });
  }

  updateEmployee(employee: Employee): Observable<any> {
    return this.http.put<any>(this.baseUrl, employee);
  }
}
