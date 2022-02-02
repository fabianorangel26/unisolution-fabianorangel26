﻿using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using UniSolution.FabianoRangel26.EntityFramework;

namespace UniSolution.FabianoRangel26.Migrations.SeedData
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages { get; private set; }

        private readonly FabianoRangel26DbContext _context;

        static DefaultLanguagesCreator()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flags gb"),
                new ApplicationLanguage(null, "tr", "Türkçe", "famfamfam-flags tr"),
                new ApplicationLanguage(null, "zh-CN", "简体中文", "famfamfam-flags cn"),
                new ApplicationLanguage(null, "pt-BR", "Português-BR", "famfamfam-flags br"),
                new ApplicationLanguage(null, "es", "Español", "famfamfam-flags es"),
                new ApplicationLanguage(null, "fr", "Français", "famfamfam-flags fr"),
                new ApplicationLanguage(null, "it", "Italiano", "famfamfam-flags it"),
                new ApplicationLanguage(null, "ja", "日本語", "famfamfam-flags jp"),
                new ApplicationLanguage(null, "nl-NL", "Nederlands", "famfamfam-flags nl"),
                new ApplicationLanguage(null, "lt", "Lietuvos", "famfamfam-flags lt")
            };
        }

        public DefaultLanguagesCreator(FabianoRangel26DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);

            _context.SaveChanges();
        }
    }
}
