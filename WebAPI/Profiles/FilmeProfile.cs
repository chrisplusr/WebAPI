namespace WebAPI.Profiles;

public class FilmeProfile {

    public FilmeProfile() {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
    }
}