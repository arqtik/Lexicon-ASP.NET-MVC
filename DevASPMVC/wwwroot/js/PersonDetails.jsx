class PersonDetails extends React.Component {
    state = {
        person: null
    }
    
    
    componentDidMount(){
        // fetch full person details
        fetch("https://localhost:5001/React/People")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        people: result
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
    
    render() {
        if (this.state.person === null){
            return <div>Loading Person...</div>
        } else {
            return (
                <div>
                    
                </div>
            );
        }
    }
}

export default PersonDetails;