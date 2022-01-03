import Error from "./ReactUtilities/Error.jsx";

class GenderSelect extends React.Component {
    render() {
        return (
            <select id={this.props.id} name={this.props.name} className={"form-select"} onChange={this.props.onChange} required>
                <option value={""}>Select</option>
                {
                    this.props.genders.map(gender =>
                        <option key={gender} value={gender}>{gender}</option>
                    )
                }
            </select>
        );
    }
}

class DataSelect extends React.Component {
    render() {
        return (
            <select id={this.props.id} name={this.props.name} className={"form-select"} onChange={this.props.onChange} required>
                <option value={""}>Select</option>
                {
                    this.props.data.map(item =>
                        <option key={item.id} value={item.id}>{item.name}</option>
                    )
                }
            </select>
        );
    }
}

class PersonCreateForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            firstName: '',
            lastName: '',
            gender: '',
            countryId: -99,
            cityId: -99,
            email: ''
        }
        
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleFirstNameChange = this.handleFirstNameChange.bind(this);
        this.handleLastNameChange = this.handleLastNameChange.bind(this);
        this.handleGenderChange = this.handleGenderChange.bind(this);
        this.handleCountryChange = this.handleCountryChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.handleEmailChange = this.handleEmailChange.bind(this);
    }
    
    handleFirstNameChange(e) {
        this.setState({firstName: e.target.value});
    } 
    handleLastNameChange(e) {
        this.setState({lastName: e.target.value});
    } 
    handleGenderChange(e) {
        this.setState({gender: e.target.value});
    } 
    handleCountryChange(e) {
        this.setState({countryId: e.target.value});
        // TODO: Change cities based on country selection
    } 
    handleCityChange(e) {
        this.setState({cityId: e.target.value});
    } 
    handleEmailChange(e) {
        this.setState({email: e.target.value});
    } 
    
    handleSubmit(e) {
        e.preventDefault();
        
        const {firstName, lastName, gender, countryId, cityId, email} = this.state;
        
        console.log(this.state);
        
        this.props.onSubmit({
            firstName: firstName,
            lastName: lastName,
            gender: gender,
            countryId: countryId,
            cityId: cityId,
            email: email
        });
    }
    
    render() {
        return (
            <div className={"container"}>
                <form onSubmit={this.handleSubmit}>
                    <div className={"mb-3"}>
                        <label htmlFor={"firstName"}>First Name</label>
                        <input id={"firstName"} name={"firstName"} type={"text"} className={"form-control"} onChange={this.handleFirstNameChange} maxLength={20} required/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"lastName"}>Last Name</label>
                        <input id={"lastName"} name={"lastName"} type={"text"} className={"form-control"} onChange={this.handleLastNameChange} maxLength={20} required/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"gender"}>Gender</label>
                        <GenderSelect id={"gender"} name={"gender"} genders={this.props.data.genders} onChange={this.handleGenderChange}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"countryId"}>Country</label>
                        <DataSelect id={"countryId"} name={"countryId"} data={this.props.data.countries} onChange={this.handleCountryChange}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"cityId"}>City</label>
                        <DataSelect id={"cityId"} name={"cityId"} data={this.props.data.cities} onChange={this.handleCityChange}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"email"}>E-mail</label>
                        <input id="email" name={"email"} type={"email"} className={"form-control"} placeholder={"name@example.com"} onChange={this.handleEmailChange} maxLength={255} required/>
                    </div>
                    <div className={"mb-3"}>
                        <button type={"submit"} className={"mb-3 btn btn-primary"}>Create Person</button>
                    </div>

                </form>
            </div>
        );
    }
}

class PersonCreate extends React.Component {
    state = {
        isLoaded: false,
        error: null,
        data: [],
        status: null
    }
    
    componentDidMount(){
        fetch("https://localhost:5001/React/GetFormData")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        data: result
                    })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            );
    }
    
    handlePersonSubmit = (person) => {
        console.log(person);
        
        const data = new FormData();
        data.append('FirstName', person.firstName);
        data.append('LastName', person.lastName);
        data.append('Gender', person.gender);
        data.append('CountryId', person.countryId)
        data.append('CityId', person.cityId);
        data.append('Email', person.email);

        fetch("https://localhost:5001/React/CreatePerson", 
            {method: "PUT", body: data})
            .then(() => this.setState({ status: 'Created person successfully' }));
        
        // clear form?
    }
    
    render() {
        const {isLoaded, error, data, status} = this.state;
        
        if (status) {
            return <div className="p-3 mb-2 bg-success text-white">{this.state.status}</div>
        }
        
        if (error){
            return <Error message={error.message}/>
        } else if(!isLoaded) {
            return <div>Loading...</div>
        } else {
            return <PersonCreateForm data={data} onSubmit={this.handlePersonSubmit}/>
        }
    }
}

export default PersonCreate;