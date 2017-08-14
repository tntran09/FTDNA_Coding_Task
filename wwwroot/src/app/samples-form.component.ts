import { Component } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Component({
  selector: 'samples-form',
  templateUrl: './samples-form.component.html',
  styleUrls: []
})
export class SamplesFormComponent {
	private SamplesUrl = 'http://localhost:5000/api/Samples';
	private StatusesUrl = 'http://localhost:5000/api/Statuses';
	
	Statuses = [];
	
	NewSample = {
		BarCode: '',
		FirstName: '',
		LastName: '',
		Status: ''
	};
	
	Status = '';
	CreatedBy = '';
	Samples = [];
	
	FilterText = '';
	FilterSamples = [];
	
	constructor(private http: Http) {
		this.http.get(this.StatusesUrl)
			.toPromise()
			.then(response => {
				this.Statuses = response.json();
			});
	}
	
	addNewSample() {
		var model = {
			BarCode: this.NewSample.BarCode,
			FirstName: this.NewSample.FirstName,
			LastName: this.NewSample.LastName,
			Status: this.NewSample.Status
		};
		
		this.http.post(this.SamplesUrl + '/create', model)
			.toPromise()
			.then(response => {
				this.NewSample = {
					BarCode: '',
					FirstName: '',
					LastName: '',
					Status: ''
				};
			})
	}
	
	search() {
		this.http.post(this.SamplesUrl + '/search', {
				Status: this.Status,
				Name: this.CreatedBy
			})
			.toPromise()
			.then(response => {
				this.Samples = response.json();
				this.FilterSamples = this.Samples.slice();
				this.FilterText = '';
			});
	}
	
	filter() {
		if (this.FilterText == '') {
			this.FilterSamples = this.Samples.slice();
			return;
		}
		
		this.FilterSamples = this.Samples.filter(item => {
			return item.barCode.toString().indexOf(this.FilterText) > -1
			|| item.status.statusName.indexOf(this.FilterText) > -1
			|| item.user.firstName.indexOf(this.FilterText) > -1
			|| item.user.lastName.indexOf(this.FilterText) > -1;
		});
	}
}
