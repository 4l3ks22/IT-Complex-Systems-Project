select profession from professions join person_profession on professions.profession_id = person_profession.profession_id
where person_profession.nconst = 'nm0000206';