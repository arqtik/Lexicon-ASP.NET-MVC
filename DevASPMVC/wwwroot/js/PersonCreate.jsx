import Error from "./ReactUtilities/Error.jsx";

class GenderSelect extends React.Component {
    render() {
        return (
            <select id={"gender"} className={"form-select"}>
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
            <select id={this.props.id} className={"form-select"}>
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
    render() {
        return (
            <div className={"container"}>
                <form onSubmit={() => this.props.onSubmit()}>
                    <div className={"mb-3"}>
                        <label htmlFor={"firstName"}>First Name</label>
                        <input id={"firstName"} type={"text"} className={"form-control"}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"lastName"}>Last Name</label>
                        <input id={"lastName"} type={"text"} className={"form-control"}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"gender"}>Gender</label>
                        <GenderSelect id={"gender"} genders={this.props.data.genders}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"countryId"}>Country</label>
                        <DataSelect id={"countryId"} data={this.props.data.countries}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"cityId"}>City</label>
                        <DataSelect id={"cityId"} data={this.props.data.cities}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"email"}>E-mail</label>
                        <input id="email" type={"email"} className={"form-control"} placeholder={"name@example.com"}/>
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
        data: []
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
    
    handleSubmit(event) {
        //event.preventDefault();
        
        // submit person?
        
        // clear form?
    }
    
    render() {
        const {isLoaded, error, data} = this.state;
        
        if (error){
            return <Error message={error.message}/>
        } else if(!isLoaded) {
            return <div>Loading...</div>
        } else {
            return <PersonCreateForm data={data} onSubmit={this.handleSubmit}/>
        }
    }
}

export default PersonCreate;