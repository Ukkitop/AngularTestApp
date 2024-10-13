import { HttpClient } from "@angular/common/http";
import { Component, OnInit, model } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, FormGroupDirective, FormsModule, NgForm, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { Country } from "../Models/Country";
import { of } from 'rxjs';
import { environment } from "../config.dev";
import { Province } from "../Models/Province";


export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'form-c',
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class TestFormComponent implements OnInit {
  register: FormGroup = new FormGroup({
    emailFormControl: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.pattern("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{2,}$")]),
    confirmPassword: new FormControl('', Validators.required),
    checkbox: new FormControl('', Validators.required)
  }, { validators: confirmPasswordValidator });


  matcher = new MyErrorStateMatcher();
  hide = true;
  constructor(private http: HttpClient) { }
  ngOnInit(): void {
    this.http.get<Country[]>(`${environment.baseUrl}country`).subscribe({
      next: (result) => this.countries = result,
      error: (e) => console.log(e)
    }
    );
  }

  countryChanged() {
    console.log(this.select1);
    this.http.get<Province[]>(`${environment.baseUrl}country/${this.select1}/GetProvinces`).subscribe({
      next: (result) => this.provinces = result,
      error: (e) => console.log(e)
    }
    );
  }

  checked = false;
  checkboxError = false;
  firstStep = true;
  secondStep = false;
  countrySelectError = false;
  provinceSelectError = false;

  countries: Country[] = [];
  provinces: Province[] = [];

  select1 = null;
  select2 = null;

  checkInputs() {
    if (this.checked == true
      && this.register.get('confirmPassword')?.errors == null
      && this.register.get('password')?.errors == null
      && this.register.get('emailFormControl')?.errors == null) {
      this.firstStep = false;
      this.secondStep = true;
    } else if (this.checked != true) {
      this.checkboxError = true;
    } else {
      this.checkboxError = false;
    }
  }

  checkInputs2() {
    if (this.select1 != null && this.select2 != null) {
      this.http.post(`${environment.baseUrl}user`, { email: this.register.get('emailFormControl')?.value, password: this.register.get('password')?.value, CountryId: this.select1, ProvinceId: this.select2 }).subscribe({
        error: (e) => console.log(e)
      }
      );
      
      this.countrySelectError = false;
      this.provinceSelectError = false;
    } else {      
      if (this.select1 == null) {
        this.countrySelectError = true;
        this.provinceSelectError = true;
      } else {
        this.countrySelectError = false;
        this.provinceSelectError = true;
      }
    }
  }

  get emailInput() { return this.register.get('emailFormControl'); }

  get passwordInput() { return this.register.get('password'); }

  get confirmPasswordInput() { return this.register.get('confirmPassword'); }
}

export const confirmPasswordValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  const password = control.get('password');
  const confirmPassword = control.get('confirmPassword');

  return password && confirmPassword && password.value === confirmPassword.value ? { confirmPassword: true } : null;
};