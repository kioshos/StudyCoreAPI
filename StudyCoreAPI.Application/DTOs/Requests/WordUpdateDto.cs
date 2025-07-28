namespace StudyCoreAPI.Application.DTOs;

public record WordUpdateDto(string Name, string PartOfSpeech, string Meaning, string? Note, string Translation);